using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Jellyfin.Plugin.Lumen.Api;

/// <summary>
/// What the Lumen app asks right after signing in. Any signed-in user may ask;
/// the address is nothing they could not find on their own.
/// </summary>
[ApiController]
[Authorize]
[Route("Lumen")]
[Produces("application/json")]
public sealed class LumenController : ControllerBase
{
    /// <summary>
    /// The Seerr address, or <c>null</c> when the admin left it empty.
    /// </summary>
    [HttpGet("Seerr")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<SeerrLink> Seerr()
    {
        var raw = Plugin.Instance?.Configuration.SeerrUrl?.Trim() ?? string.Empty;

        if (raw.Length == 0)
        {
            return new SeerrLink(null);
        }

        if (!raw.Contains("://", StringComparison.Ordinal))
        {
            raw = "https://" + raw;
        }

        return new SeerrLink(raw.TrimEnd('/'));
    }
}

public sealed record SeerrLink(string? Url);
