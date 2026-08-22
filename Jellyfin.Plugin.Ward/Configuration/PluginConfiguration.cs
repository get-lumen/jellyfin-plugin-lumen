using MediaBrowser.Model.Plugins;

namespace Jellyfin.Plugin.Ward.Configuration;

public sealed class PluginConfiguration : BasePluginConfiguration
{
    /// <summary>
    /// The address users reach Seerr on, e.g. https://seerr.example.com.
    /// Empty means "no Seerr here".
    /// </summary>
    public string SeerrUrl { get; set; } = string.Empty;
}
