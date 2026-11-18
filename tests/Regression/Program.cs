using ChestCounter;

// Regression checks of the Japanese edition: Japanese texts, match time and averages, efficiency, history edits.
// Run: dotnet run --project tests/Regression -c Release
var failures = 0;
var passed = 0;
void Check(string name, bool ok, string? detail = null)
{
    if (ok)
    {
        passed++;
        Console.WriteLine($"  ok   {name}");
    }
    else
    {
        failures++;
        Console.WriteLine($"  FAIL {name}{(detail != null ? " — " + detail : "")}");
    }
}

var t0 = new DateTime(2026, 11, 10, 12, 0, 0, DateTimeKind.Utc);
MatchRecord Match(string id, int minutesAfter, int chests, int? seconds, string player = "Player", int manual = 0) => new()
{
    SessionId = id,
    MatchStartUtc = t0.AddMinutes(minutesAfter),
    AnalyzedAtUtc = t0.AddMinutes(minutesAfter + 30),
    DurationSeconds = seconds,
    ChestsOpened = chests,
    ManualChestsAdded = manual,
    PlayerName = player,
    EpicId = player.ToLowerInvariant(),
    Playlist = "Playlist_DefaultSolo",
    Map = "/Delilah/Maps/Delilah_Terrain",
    Placement = 3,
    TotalPlayers = 100,
    ReplayFile = id + ".replay",
    AnalyzerVersion = ReplayAnalyzer.CurrentVersion,
};

Console.WriteLine("Japanese");
L.Set("ja");
Check("ja is offered", L.Codes.Contains("ja") && L.NativeName("ja") == "日本語");
Check("Normalize recognizes Japanese", L.Normalize("日本語") == "ja" && L.Normalize("JA") == "ja" && L.Normalize("japanese") == "ja");
Check("T picks Japanese", L.T("fr", "en", "es", "ja") == "ja");
Check("T falls back to English", L.T("fr", "en", "es") == "en");
Check("Count with a pattern", L.Count(1234, "coffre", "chest", "cofre", "{0}個") == "1,234個", L.Count(1234, "coffre", "chest", "cofre", "{0}個"));
Check("Count without a pattern: English words", L.Count(2, "coffre", "chest", "cofre") == "2 chests");
Check("Ordinal", L.Ordinal(3) == "3位");
Check("Week name", L.WeekName(3) == "第3週");
Check("Culture", L.Culture.Name == "ja-JP");
Check("Stored names translated", L.Name("Coffre rare") == "レア宝箱" && L.Name("Caisse de munitions") == "弾薬箱");
L.ClockFormat = "12";
Check("12-hour clock in Japanese order", L.TimePattern() == "tt h:mm");
L.ClockFormat = "auto";
var texts = GuiPage.Texts();
L.Set("en");
var english = GuiPage.Texts();
L.Set("ja");
var untranslated = texts.Where(kv => kv.Value == english[kv.Key] && kv.Value is not ("OK")).Select(kv => kv.Key).ToList();
Check("Every text of the window in Japanese", untranslated.Count == 0, string.Join(", ", untranslated));
Check("Release notes: Japanese section", ReleaseNotes.WhatsNew(ReleaseNotes.Embedded, "ja") is { Count: 3 } jaNotes && jaNotes[0].StartsWith("カード型オーバーレイ"),
    string.Join(" | ", ReleaseNotes.WhatsNew(ReleaseNotes.Embedded, "ja")));
Check("Release notes: other languages keep theirs", ReleaseNotes.WhatsNew(ReleaseNotes.Embedded, "en") is { Count: 3 } en && en[0].StartsWith("Card overlay")
    && ReleaseNotes.WhatsNew(ReleaseNotes.Embedded, "fr").Count == 3 && ReleaseNotes.WhatsNew(ReleaseNotes.Embedded, "es").Count == 3);
Check("Version", AppInfo.VersionText == "1.6.1", AppInfo.VersionText);
Check("Durations", L.Duration(1267) == "21:07" && L.Duration(null) == "—" && L.Duration(0) == "—" && L.Duration(-5) == "—");

Console.WriteLine("Match time and averages");
var a = Match("a", 0, 20, 1200);  // 1.00 / min
var b = Match("b", 60, 30, 1200); // 1.50 / min
var c = Match("c", 120, 10, null);
var d = Match("d", 180, 0, 0);
var e = Match("e", 240, 10, 601); // 0.998 / min, below the 1.25 of a and b
var all = new List<MatchRecord> { a, b, c, d, e };
Check("Average time ignores unknown, zero and negative durations", MatchStats.AverageDurationSeconds(all) == 1000, MatchStats.AverageDurationSeconds(all)?.ToString());
Check("Average time rounds to the second", MatchStats.AverageDurationSeconds(new[] { Match("x", 0, 1, 100), Match("y", 1, 1, 101) }) == 101);
Check("Average time of nothing", MatchStats.AverageDurationSeconds(new[] { c, d }) == null);
Check("Chests per minute: total chests ÷ total time", Math.Abs(MatchStats.ChestsPerMinute(all)!.Value - 60.0 * 60 / 3001) < 1e-9);
Check("Chests per minute of a match", MatchStats.ChestsPerMinute(b) == 1.5 && MatchStats.ChestsPerMinute(c) == null);

Console.WriteLine("Efficiency");
var effA = MatchStats.Of(a, all);
Check("First match: nothing to compare with", effA is { PastRate: null } && effA.Rate == 1.0);
var effB = MatchStats.Of(b, all);
Check("Above the earlier average", effB is { Comparison: 1, PastRate: 1.0 });
var effE = MatchStats.Of(e, all);
Check("Below the earlier average", effE is { Comparison: -1 } && Math.Abs(effE.PastRate!.Value - 50.0 / 40) < 1e-9);
Check("Unknown duration: no efficiency", MatchStats.Of(c, all) == null);
var equal = Match("f", 300, 25, 1200); // 1.25 / min = (20+30+13) / (2400+601)? no: compare exactly with a copy of the past
var past = new List<MatchRecord> { Match("p1", 0, 10, 600), Match("p2", 10, 30, 1800), equal };
equal.ChestsOpened = 40; equal.DurationSeconds = 2400;
Check("Equal to the average (exact comparison)", MatchStats.Of(equal, past) is { Comparison: 0 });
var other = Match("o", 30, 99, 60, player: "Other");
var mixed = new List<MatchRecord>(all) { other };
Check("Other profiles are not compared", MatchStats.Of(b, mixed) is { PastRate: 1.0 });
var allAtOnce = MatchStats.OfAll(mixed);
Check("One pass = one by one", mixed.All(m => Equals(allAtOnce[m], MatchStats.Of(m, mixed))));
var same1 = Match("s1", 500, 10, 600);
var same2 = Match("s2", 500, 30, 600);
var sameTime = MatchStats.OfAll(new[] { same1, same2 });
Check("Matches of the same moment are not earlier than each other", sameTime[same1]!.PastRate == null && sameTime[same2]!.PastRate == null);
Check("Japanese description", MatchStats.Describe(b, all) == "1.50個/分 · 平均を上回る（平均 1.00）", MatchStats.Describe(b, all));

Console.WriteLine("History edits");
var data = new TrackerData { Matches = { Match("m1", 0, 10, 900), Match("m2", 60, 5, 900) } };
Check("Add chests", MatchHistory.Adjust(data, "m1", 3) == 3 && data.Matches[0] is { ChestsOpened: 13, ManualChestsAdded: 3 });
Check("Remove chests, never below zero", MatchHistory.Adjust(data, "m2", -8) == -5 && data.Matches[1] is { ChestsOpened: 0, ManualChestsAdded: -5 });
Check("Unknown match: nothing", MatchHistory.Adjust(data, "nope", 5) == 0);
Check("Never above the maximum", MatchHistory.Adjust(data, "m1", int.MaxValue) == MatchHistory.MaxChests - 13 && data.Matches[0].ChestsOpened == MatchHistory.MaxChests);
Check("Back to the replay's count", MatchHistory.ResetAdjust(data, "m1") && data.Matches[0] is { ChestsOpened: 10, ManualChestsAdded: 0 } && !MatchHistory.ResetAdjust(data, "m1"));
Check("Delete", MatchHistory.Delete(data, "m2", t0) && data.Matches.Count == 1 && data.DeletedMatches is [{ SessionId: "m2", DeletedUtc: not null }] && MatchHistory.IsDeleted(data, "m2"));
Check("Deleted matches leave the totals", data.CountedChests == 10);
Check("Restore", MatchHistory.Restore(data, "m2") && data.Matches.Count == 2 && data.DeletedMatches.Count == 0 && data.Matches[1].DeletedUtc == null);
Check("Restore keeps the correction", data.Matches[1] is { ChestsOpened: 0, ManualChestsAdded: -5 });
var fresh = Match("m3", 0, 12, 900);
var old = Match("m3", 0, 9, 900);
old.ManualChestsAdded = 4; old.ChestsOpened = 13;
MatchHistory.CarryOver(fresh, old);
Check("A new analysis keeps the correction", fresh is { ChestsOpened: 16, ManualChestsAdded: 4 });
var fresh2 = Match("m4", 0, 2, 900);
var old2 = Match("m4", 0, 0, 900);
old2.ManualChestsAdded = -5;
MatchHistory.CarryOver(fresh2, old2);
Check("A new analysis never goes below zero", fresh2 is { ChestsOpened: 0, ManualChestsAdded: -2 });
var json = System.Text.Json.JsonSerializer.Serialize(data);
var back = System.Text.Json.JsonSerializer.Deserialize<TrackerData>(json)!;
Check("Saved and read back", back.Matches[1].ManualChestsAdded == -5);
var oldFile = System.Text.Json.JsonSerializer.Deserialize<TrackerData>("{\"Matches\":[{\"SessionId\":\"z\",\"ChestsOpened\":7}]}")!;
Check("Files of 1.5.1 read without corrections", oldFile.Matches[0].ManualChestsAdded == 0 && oldFile.DeletedMatches.Count == 0);

Console.WriteLine("Transfer from another account");
{
    // Week 3 of the hunt (content.json): 2026-11-15 14:00 to 2026-11-22 14:00 UTC.
    var now = new DateTime(2026, 11, 18, 12, 0, 0, DateTimeKind.Utc);
    var old1 = Match("o1", 0, 30, 900, player: "OldMain");            // Nov 10: before this week
    old1.MatchStartUtc = new DateTime(2026, 11, 10, 12, 0, 0, DateTimeKind.Utc);
    var oldB = Match("o2", 0, 12, 900, player: "OldMain");            // Nov 17: this week
    oldB.MatchStartUtc = new DateTime(2026, 11, 17, 12, 0, 0, DateTimeKind.Utc);
    var mine = Match("n1", 0, 5, 900, player: "NewMain");
    mine.MatchStartUtc = new DateTime(2026, 11, 18, 10, 0, 0, DateTimeKind.Utc);
    var td = new TrackerData { Matches = { old1, oldB, mine }, ManualChests = { ["oldmain"] = 8 },
        ManualHistory = { ["oldmain"] = new List<ManualEntry> { new() { Id = "h1", Chests = 8, Kind = ManualEntry.Hand } } } };
    var cfg = new Config { Profile = "newmain" };
    var sources = Profiles.TransferSources(td, cfg, now);
    Check("Other accounts offered", sources is [{ Key: "oldmain", Chests: 50, ThisWeek: 12 }], string.Join(", ", sources));
    var moved = Profiles.TransferFrom(td, cfg, "oldmain", now);
    var view = Profiles.View(td, cfg);
    Check("Moved: replays + added by hand", moved is { Chests: 50 } && view.TotalChests == 55, view.TotalChests.ToString());
    var hist = Profiles.ManualHistory(td, cfg);
    Check("Two entries: this week and the rest", hist.Count(e => e.Kind == ManualEntry.Transfer) == 2
        && hist.Single(e => e.WeekFromUtc != null).Chests == 12 && hist.Single(e => e.Kind == ManualEntry.Transfer && e.WeekFromUtc == null).Chests == 38);
    Check("Shown with the account's name", hist.All(e => e.FromName == "OldMain"));
    oldB.ChestsOpened = 20; // played again on the old account
    Profiles.TransferFrom(td, cfg, "oldmain", now);
    Check("Moving again replaces the transfer", Profiles.View(td, cfg).TotalChests == 63, Profiles.View(td, cfg).TotalChests.ToString());
    Check("The other account does not change", td.ManualChests["oldmain"] == 8);
    var reverse = new Config { Profile = "oldmain" };
    Check("No double count reverse and forth", Profiles.TransferSources(td, reverse, now) is [{ Key: "newmain", Chests: 5 }]);
    Check("Not from the account shown", Profiles.TransferFrom(td, cfg, "newmain", now) == null && Profiles.TransferFrom(td, cfg, "nobody", now) == null);
    var undo = Profiles.ManualHistory(td, cfg).Where(e => e.Kind == ManualEntry.Transfer).Select(e => e.Id).ToList();
    undo.ForEach(id => Profiles.RemoveManual(td, cfg, id));
    Check("Undone with the cross", Profiles.View(td, cfg).TotalChests == 5);
}

Console.WriteLine("Report and CSV in Japanese");
var reportData = new TrackerData { AnalyzerVersion = ReplayAnalyzer.CurrentVersion, Matches = { a, b, e } };
b.ManualChestsAdded = 2;
var config = new Config { Language = "ja" };
string html = "";
try
{
    html = ReportWriter.Report(config, Profiles.View(reportData, config), Profiles.List(reportData));
}
catch (Exception ex)
{
    Check("Report written", false, ex.ToString());
}
Check("Report: Japanese page", html.Contains("<html lang=\"ja\"") && html.Contains("宝箱カウンター"));
Check("Report: average match time tile", html.Contains("平均試合時間") && html.Contains(L.Duration(MatchStats.AverageDurationSeconds(reportData.Matches))));
Check("Report: chests per minute tile", html.Contains("1分あたりの宝箱"));
Check("Report: time and efficiency columns", html.Contains("<th style=\"text-align:right\">試合時間</th>") && html.Contains("効率") && html.Contains("▲") && html.Contains("▼"));
Check("Report: correction marked", html.Contains("手動で補正"));
var csv = ReportWriter.Csv(reportData);
var lines = csv.Split('\n', StringSplitOptions.RemoveEmptyEntries);
Check("CSV: Japanese header with the new columns", lines[0].StartsWith("日時;") && lines[0].TrimEnd().EndsWith("試合時間_秒;手動補正;1分あたりの宝箱"), lines[0]);
Check("CSV: duration, correction and rate", lines.Any(l => l.TrimEnd().EndsWith(";1200;2;1.50")), string.Join(" / ", lines.Skip(1)));
L.Set("fr");
Check("CSV: French header keeps its order", ReportWriter.Csv(reportData).StartsWith("date;mode;joueur;place;joueurs;coffres;coffres_coequipiers;caisses_munitions;tresors;fichier;duree_s"));

Console.WriteLine();
Console.WriteLine($"{passed} passed, {failures} failed");
return failures == 0 ? 0 : 1;
