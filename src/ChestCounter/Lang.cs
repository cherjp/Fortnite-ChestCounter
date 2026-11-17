using System.Globalization;

namespace ChestCounter;

/// <summary>
/// User interface language (French, English, Spanish or Japanese), chosen on first launch and saved in config.json.
/// Texts are written inline as <c>L.T("français", "English", "español", "日本語")</c> (no Japanese text: the English one). Names stored in data.json (chest kinds,
/// treasure items) are kept in French for compatibility and translated when displayed (<see cref="Name"/>).
/// </summary>
public static class L
{
    /// <summary>Languages offered, in menu order.</summary>
    public static readonly string[] Codes = { "fr", "en", "es", "ja" };

    /// <summary>"fr", "en", "es" or "ja".</summary>
    public static string Code { get; private set; } = "fr";

    public static bool En => Code == "en";
    public static bool Es => Code == "es";
    public static bool Ja => Code == "ja";

    public static CultureInfo Culture { get; private set; } = CultureInfo.GetCultureInfo("fr-FR");

    public static void Set(string? code)
    {
        Code = Normalize(code) ?? "fr";
        Culture = CultureInfo.GetCultureInfo(T("fr-FR", "en-GB", "es-ES", "ja-JP"));
    }

    /// <summary>"fr", "en", "es", "ja" or null when the answer is not recognized.</summary>
    public static string? Normalize(string? code) => code?.Trim().ToLowerInvariant() switch
    {
        "fr" or "fra" or "fre" or "french" or "français" or "francais" or "francés" or "frances" => "fr",
        "en" or "eng" or "english" or "anglais" or "inglés" or "ingles" => "en",
        "es" or "spa" or "spanish" or "español" or "espanol" or "espagnol" => "es",
        "ja" or "jp" or "jpn" or "ja-jp" or "japanese" or "japonais" or "japonés" or "japones" or "日本語" => "ja",
        _ => null,
    };

    /// <summary>Name of a language in that language (menus).</summary>
    public static string NativeName(string code) => code switch { "en" => "English", "es" => "Español", "ja" => "日本語", _ => "Français" };

    /// <summary>Language of Windows when it is one of ours, English otherwise.</summary>
    public static string SystemDefault => Normalize(CultureInfo.CurrentUICulture.TwoLetterISOLanguageName) ?? "en";

    public static string T(string fr, string en, string es, string? ja = null) => Code switch { "en" => en, "es" => es, "ja" => ja ?? en, _ => fr };

    public static string N(int n) => n.ToString("N0", Culture);

    /// <summary>"3 coffres" / "3 chests" / "3 cofres" / "3個" (regular plurals: + "s").</summary>
    public static string Count(int n, string fr, string en, string es, string? ja = null) => Count(n, fr, fr + "s", en, en + "s", es, es + "s", ja);

    /// <summary>
    /// French: singular for 0 and 1. English and Spanish: singular for 1 only. Japanese has no plural: <paramref name="ja"/>
    /// is a pattern where {0} is the number ("{0}個", "{0}試合"); without it, the English words.
    /// </summary>
    public static string Count(int n, string frOne, string frMany, string enOne, string enMany, string esOne, string esMany, string? ja = null) => Code switch
    {
        "ja" when ja != null => ja.Contains("{0}") ? ja.Replace("{0}", N(n)) : N(n) + ja,
        "en" or "ja" => $"{N(n)} {(n == 1 ? enOne : enMany)}",
        "es" => $"{N(n)} {(n == 1 ? esOne : esMany)}",
        _ => $"{N(n)} {(n > 1 ? frMany : frOne)}",
    };

    /// <summary>"12e" / "12th" / "12.º" / "12位".</summary>
    public static string Ordinal(int n)
    {
        if (Ja)
        {
            return $"{n}位";
        }
        if (Es)
        {
            return $"{n}.º";
        }
        if (!En)
        {
            return n == 1 ? "1er" : $"{n}e";
        }
        var suffix = (n % 100) is 11 or 12 or 13 ? "th" : (n % 10) switch { 1 => "st", 2 => "nd", 3 => "rd", _ => "th" };
        return $"{n}{suffix}";
    }

    // ---- Times shown to the player (Settings): local time or UTC, 12- or 24-hour clock ------------------

    /// <summary>Show times in UTC instead of the PC's time zone.</summary>
    public static bool UtcTimes { get; set; }

    /// <summary>"auto" (the Windows setting), "12" or "24".</summary>
    public static string ClockFormat { get; set; } = "auto";

    /// <summary>The Windows setting: 24-hour unless the short time pattern has an "h" (12-hour) in it.</summary>
    public static bool WindowsClock24 => !CultureInfo.CurrentCulture.DateTimeFormat.ShortTimePattern.Contains('h');

    public static bool Clock24 => ClockFormat switch { "12" => false, "24" => true, _ => WindowsClock24 };

    /// <summary>A UTC moment as it is shown: in UTC or in the PC's time zone.</summary>
    public static DateTime Shown(DateTime utc)
    {
        var u = utc.Kind == DateTimeKind.Local ? utc.ToUniversalTime() : DateTime.SpecifyKind(utc, DateTimeKind.Utc);
        return UtcTimes ? u : u.ToLocalTime();
    }

    /// <summary>" UTC" after a time shown in UTC, nothing in local time.</summary>
    public static string Zone => UtcTimes ? " UTC" : "";

    /// <summary>The .NET pattern of a time of day ("HH:mm" / "h:mm tt"), with seconds or not.</summary>
    public static string TimePattern(bool seconds = false) => Clock24 ? (seconds ? "HH:mm:ss" : "HH:mm")
        : Ja ? (seconds ? "tt h:mm:ss" : "tt h:mm") // 午後 10:54
        : (seconds ? "h:mm:ss tt" : "h:mm tt");

    /// <summary>A time of day of a moment already converted by <see cref="Shown"/> ("22:54" / "10:54 PM", + " UTC").</summary>
    public static string Clock(DateTime shown, bool seconds = false) => shown.ToString(TimePattern(seconds), Culture) + Zone;

    /// <summary>Time stamp of the activity log, now ("[22:54:07]").</summary>
    public static string Stamp => $"[{Clock(Shown(DateTime.UtcNow), seconds: true)}]";

    /// <summary>The PC's time zone as an offset from UTC ("UTC−8", "UTC+5:30").</summary>
    public static string LocalOffset
    {
        get
        {
            var o = TimeZoneInfo.Local.GetUtcOffset(DateTime.UtcNow);
            var sign = o < TimeSpan.Zero ? "−" : "+";
            o = o.Duration();
            return o == TimeSpan.Zero ? "UTC" : $"UTC{sign}{o.Hours}{(o.Minutes != 0 ? $":{o.Minutes:00}" : "")}";
        }
    }

    /// <summary>Short date + time of a match ("05/11 22:54" / "5 Nov 10:54 PM"), of a moment already converted by <see cref="Shown"/>.</summary>
    public static string DateTimeShort(DateTime shown) => shown.ToString((Ja ? "M/d " : En ? "d MMM " : "dd/MM ") + TimePattern(), Culture) + Zone;

    /// <summary>"Semaine 3" / "Week 3" / "Semana 3" / "第3週".</summary>
    public static string WeekName(int n) => Ja ? $"第{n}週" : $"{T("Semaine", "Week", "Semana")} {n}";

    /// <summary>A duration in minutes and seconds ("21:07"), "—" when unknown.</summary>
    public static string Duration(int? seconds) => seconds is > 0 and var s ? $"{s / 60}:{s % 60:00}" : "—";

    // French names stored in data.json -> English / Spanish / Japanese display names.
    private static readonly Dictionary<string, (string En, string Es, string Ja)> Names = new(StringComparer.OrdinalIgnoreCase)
    {
        ["Coffre"] = ("Chest", "Cofre", "宝箱"),
        ["Coffre rare"] = ("Rare chest", "Cofre raro", "レア宝箱"),
        ["Coffre enterré"] = ("Buried chest", "Cofre enterrado", "埋められた宝箱"),
        ["Coffre d'esprit (rare)"] = ("Sprite chest (rare)", "Cofre de espíritu (raro)", "スプライトの宝箱（レア）"),
        ["Coffre des affiches d'esprit"] = ("Sprite poster chest", "Cofre de los carteles de espíritu", "スプライトのポスターの宝箱"),
        ["Autre coffre"] = ("Other chest", "Otro cofre", "その他の宝箱"),
        ["Canon à butin"] = ("Loot cannon", "Cañón de botín", "戦利品キャノン"),
        ["Caisse de munitions"] = ("Ammo box", "Caja de munición", "弾薬箱"),
        ["Caisse de nourriture"] = ("Food box", "Caja de comida", "食料箱"),
        ["Autre conteneur"] = ("Other container", "Otro contenedor", "その他のコンテナ"),
        ["Trésor"] = ("Treasure", "Tesoro", "お宝"),
        ["Trésor (type inconnu)"] = ("Treasure (unknown type)", "Tesoro (tipo desconocido)", "お宝（種類不明）"),
        ["Feu d'artifice doré"] = ("Golden firework", "Fuego artificial dorado", "ゴールドの花火"),
        ["Extracteur portable"] = ("Portable extractor", "Extractor portátil", "携帯型エクストラクター"),
        ["Localisateur d'esprit"] = ("Sprite locator", "Localizador de espíritus", "スプライトロケーター"),
        ["Localisateur chanceux"] = ("Lucky locator", "Localizador de la suerte", "ラッキーロケーター"),
        ["Accélérateur d'extraction"] = ("Extraction accelerator", "Acelerador de extracción", "抽出アクセラレーター"),
        ["inconnu"] = ("unknown", "desconocido", "不明"),
    };

    /// <summary>Display name of a chest kind or treasure item stored in French.</summary>
    public static string Name(string? stored)
    {
        if (stored != null)
        {
            stored = ChestKinds.Canonical(stored); // older name of a kind
            stored = TreasureNames.Canonical(stored);
        }
        if (string.IsNullOrEmpty(stored) || Code == "fr" || !Names.TryGetValue(stored, out var t))
        {
            return stored ?? "";
        }
        return Ja ? t.Ja : En ? t.En : t.Es;
    }
}
