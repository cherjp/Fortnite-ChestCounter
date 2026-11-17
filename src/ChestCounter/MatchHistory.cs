namespace ChestCounter;

/// <summary>
/// Match time and averages: average duration of a match, chests per minute, and the efficiency of one match compared
/// with the player's earlier matches.
/// </summary>
public static class MatchStats
{
    /// <summary>Average duration of the matches whose duration is known (rounded to the second), null when none is.</summary>
    public static int? AverageDurationSeconds(IEnumerable<MatchRecord> matches)
    {
        long sum = 0, count = 0;
        foreach (var m in matches)
        {
            if (m.DurationSeconds is > 0 and var s)
            {
                sum += s;
                count++;
            }
        }
        return count == 0 ? null : (int)Math.Round((double)sum / count, MidpointRounding.AwayFromZero);
    }

    /// <summary>Chests per minute over the matches whose duration is known (total chests ÷ total time).</summary>
    public static double? ChestsPerMinute(IEnumerable<MatchRecord> matches)
    {
        long seconds = 0, chests = 0;
        foreach (var m in matches)
        {
            if (m.DurationSeconds is > 0 and var s)
            {
                seconds += s;
                chests += m.ChestsOpened;
            }
        }
        return seconds == 0 ? null : 60.0 * chests / seconds;
    }

    /// <summary>Chests per minute of one match (null when its duration is unknown).</summary>
    public static double? ChestsPerMinute(MatchRecord m) => m.DurationSeconds is > 0 and var s ? 60.0 * m.ChestsOpened / s : null;

    /// <summary>
    /// Efficiency of a match: its chests per minute, the rate of the same profile's earlier matches (null when there is
    /// none to compare with) and the comparison (+1 above, −1 below, 0 equal).
    /// </summary>
    public sealed record Efficiency(double Rate, double? PastRate, int Comparison);

    public static Efficiency? Of(MatchRecord match, IEnumerable<MatchRecord> history)
    {
        var profile = Profiles.Key(match);
        var start = match.MatchStartUtc ?? match.AnalyzedAtUtc;
        long pastSeconds = 0, pastChests = 0;
        foreach (var m in history)
        {
            if (!ReferenceEquals(m, match) && m.DurationSeconds is > 0 and var s && Profiles.Key(m) == profile && (m.MatchStartUtc ?? m.AnalyzedAtUtc) < start)
            {
                pastSeconds += s;
                pastChests += m.ChestsOpened;
            }
        }
        return Make(match, pastSeconds, pastChests);
    }

    /// <summary>
    /// <see cref="Of"/> for every match at once (one pass per profile instead of one per match): the history tab and the
    /// report show it on each row.
    /// </summary>
    public static Dictionary<MatchRecord, Efficiency?> OfAll(IEnumerable<MatchRecord> matches)
    {
        var result = new Dictionary<MatchRecord, Efficiency?>();
        foreach (var profile in matches.GroupBy(Profiles.Key))
        {
            long pastSeconds = 0, pastChests = 0;
            // Matches that started at the same moment are not "earlier" than each other.
            foreach (var group in profile.GroupBy(m => m.MatchStartUtc ?? m.AnalyzedAtUtc).OrderBy(g => g.Key))
            {
                foreach (var m in group)
                {
                    result[m] = Make(m, pastSeconds, pastChests);
                }
                foreach (var m in group)
                {
                    if (m.DurationSeconds is > 0 and var s)
                    {
                        pastSeconds += s;
                        pastChests += m.ChestsOpened;
                    }
                }
            }
        }
        return result;
    }

    private static Efficiency? Make(MatchRecord match, long pastSeconds, long pastChests)
    {
        if (match.DurationSeconds is not (> 0 and var seconds))
        {
            return null;
        }
        var rate = 60.0 * match.ChestsOpened / seconds;
        if (pastSeconds == 0)
        {
            return new Efficiency(rate, null, 0);
        }
        // Compared exactly (chests × seconds), not on rounded rates.
        var comparison = ((decimal)match.ChestsOpened * pastSeconds).CompareTo((decimal)pastChests * seconds);
        return new Efficiency(rate, 60.0 * pastChests / pastSeconds, Math.Sign(comparison));
    }

    /// <summary>"1.52" (two decimals, in the language's format).</summary>
    public static string Rate(double rate) => rate.ToString("0.00", L.Culture);

    /// <summary>"1.52 chests/min" / "1.52個/分".</summary>
    public static string RateText(double rate)
    {
        var r = Rate(rate);
        return L.T($"{r} coffres/min", $"{r} chests/min", $"{r} cofres/min", $"{r}個/分");
    }

    /// <summary>"above your average (avg. 1.31)" / "平均を上回る（平均 1.31）", or "no earlier match to compare with".</summary>
    public static string Comparison(Efficiency e)
    {
        if (e.PastRate is not double past)
        {
            return L.T("aucune partie précédente pour comparer", "no earlier match to compare with", "ninguna partida anterior para comparar", "比較できる過去の試合なし");
        }
        var label = e.Comparison switch
        {
            > 0 => L.T("au-dessus de ta moyenne", "above your average", "por encima de tu media", "平均を上回る"),
            < 0 => L.T("en dessous de ta moyenne", "below your average", "por debajo de tu media", "平均を下回る"),
            _ => L.T("dans ta moyenne", "equal to your average", "igual a tu media", "平均と同じ"),
        };
        var avg = Rate(past);
        return L.T($"{label} (moy. {avg})", $"{label} (avg. {avg})", $"{label} (media {avg})", $"{label}（平均 {avg}）");
    }

    /// <summary>"1.52 chests/min · above your average (avg. 1.31)", "—" when the duration is unknown.</summary>
    public static string Describe(MatchRecord match, IEnumerable<MatchRecord> history) =>
        Of(match, history) is { } e ? $"{RateText(e.Rate)} · {Comparison(e)}" : "—";
}

/// <summary>
/// Changes the player makes to the match history (history tab): chests added to or removed from a match, matches deleted
/// and restored. What the player changed is kept when the replay is analyzed again.
/// </summary>
public static class MatchHistory
{
    /// <summary>Most chests one match can hold.</summary>
    public const int MaxChests = 10_000;

    public static MatchRecord? Find(TrackerData d, string sessionId) => d.Matches.FirstOrDefault(m => m.SessionId == sessionId);

    public static bool IsDeleted(TrackerData d, string sessionId) => d.DeletedMatches.Any(m => m.SessionId == sessionId);

    /// <summary>
    /// Adds chests to a match (removes them when negative). The match never goes below 0 nor above <see cref="MaxChests"/>.
    /// Returns the change actually made.
    /// </summary>
    public static int Adjust(TrackerData d, string sessionId, int chests)
    {
        if (Find(d, sessionId) is not { } m)
        {
            return 0;
        }
        var total = (int)Math.Clamp((long)m.ChestsOpened + chests, 0, MaxChests);
        var applied = total - m.ChestsOpened;
        m.ChestsOpened = total;
        m.ManualChestsAdded += applied;
        return applied;
    }

    /// <summary>Back to the chests counted in the replay. Returns false when nothing was changed by hand.</summary>
    public static bool ResetAdjust(TrackerData d, string sessionId)
    {
        if (Find(d, sessionId) is not { ManualChestsAdded: not 0 } m)
        {
            return false;
        }
        m.ChestsOpened = Math.Max(0, m.ChestsOpened - m.ManualChestsAdded);
        m.ManualChestsAdded = 0;
        return true;
    }

    /// <summary>Takes a match out of the history (kept in <see cref="TrackerData.DeletedMatches"/> to be restored).</summary>
    public static bool Delete(TrackerData d, string sessionId, DateTime? nowUtc = null)
    {
        if (Find(d, sessionId) is not { } m)
        {
            return false;
        }
        d.Matches.Remove(m);
        d.DeletedMatches.RemoveAll(x => x.SessionId == sessionId);
        m.DeletedUtc = nowUtc ?? DateTime.UtcNow;
        d.DeletedMatches.Add(m);
        return true;
    }

    /// <summary>Puts a deleted match back in the history.</summary>
    public static bool Restore(TrackerData d, string sessionId)
    {
        var m = d.DeletedMatches.FirstOrDefault(x => x.SessionId == sessionId);
        if (m == null)
        {
            return false;
        }
        d.DeletedMatches.Remove(m);
        m.DeletedUtc = null;
        if (Find(d, sessionId) == null)
        {
            d.Matches.Add(m);
        }
        return true;
    }

    /// <summary>
    /// The replay of a match was analyzed again (newer version of the tool): the new record keeps the chests the
    /// player added or removed by hand.
    /// </summary>
    public static void CarryOver(MatchRecord fresh, MatchRecord old)
    {
        if (old.ManualChestsAdded == 0)
        {
            return;
        }
        var counted = fresh.ChestsOpened - fresh.ManualChestsAdded;
        var total = (int)Math.Clamp((long)counted + old.ManualChestsAdded, 0, MaxChests);
        fresh.ChestsOpened = total;
        fresh.ManualChestsAdded = total - counted;
    }
}
