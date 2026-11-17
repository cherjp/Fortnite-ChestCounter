namespace ChestCounter;

/// <summary>
/// The picture of the chest on the card overlay. A PNG named <c>overlay-chest.png</c> placed in the data folder replaces
/// the app's own chest (for example the game's chest icon, exported by the player); without it, the app's icon is used.
/// Nothing is downloaded or bundled: the player's file stays on the player's PC.
/// </summary>
public static class ChestPicture
{
    public const string FileName = "overlay-chest.png";

    /// <summary>Data folder (set at startup).</summary>
    public static string? Folder { get; set; }

    /// <summary>The player's picture, when there is one.</summary>
    public static string? CustomPath => Folder != null && File.Exists(Path.Combine(Folder, FileName)) ? Path.Combine(Folder, FileName) : null;

    /// <summary>The player's picture as a data: URI for the OBS page (null without one, or when it is not a usable PNG).</summary>
    public static string? DataUri()
    {
        try
        {
            if (CustomPath is not { } path)
            {
                return null;
            }
            var bytes = File.ReadAllBytes(path);
            // A PNG of at most 4 MB (the OBS page is rewritten every few seconds).
            var png = bytes.Length is > 8 and <= 4 << 20 && bytes[0] == 0x89 && bytes[1] == (byte)'P' && bytes[2] == (byte)'N' && bytes[3] == (byte)'G';
            return png ? "data:image/png;base64," + Convert.ToBase64String(bytes) : null;
        }
        catch
        {
            return null;
        }
    }
}
