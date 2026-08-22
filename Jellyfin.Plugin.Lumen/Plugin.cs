using System;
using System.Collections.Generic;
using Jellyfin.Plugin.Lumen.Configuration;
using MediaBrowser.Common.Configuration;
using MediaBrowser.Common.Plugins;
using MediaBrowser.Model.Plugins;
using MediaBrowser.Model.Serialization;

namespace Jellyfin.Plugin.Lumen;

/// <summary>
/// Tells the Lumen app where this server's Seerr lives, so signing in to
/// Jellyfin is all a user ever has to do.
/// </summary>
public sealed class Plugin : BasePlugin<PluginConfiguration>, IHasWebPages
{
    public Plugin(IApplicationPaths applicationPaths, IXmlSerializer xmlSerializer)
        : base(applicationPaths, xmlSerializer)
    {
        Instance = this;
    }

    public static Plugin? Instance { get; private set; }

    public override string Name => "Lumen";

    public override Guid Id => Guid.Parse("793ea59c-eca9-4462-9496-73ad169b8300");

    public override string Description => "Points the Lumen app at your Seerr.";

    public IEnumerable<PluginPageInfo> GetPages()
    {
        yield return new PluginPageInfo
        {
            Name = Name,
            EmbeddedResourcePath = $"{GetType().Namespace}.Configuration.configPage.html",
        };
    }
}
