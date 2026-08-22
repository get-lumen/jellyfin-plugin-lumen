# Jellyfin plugin: Lumen

Lets the [Lumen](https://github.com/OrangeJuiced/Lumen) app find your Seerr automatically. Set the Seerr address once in Jellyfin; every user who signs in to Lumen gets requests without typing anything.

## Install

1. Jellyfin dashboard → Plugins → Repositories → add
   `https://orangejuiced.github.io/jellyfin-plugin-lumen/manifest.json`
2. Catalog → Lumen → Install, restart Jellyfin.
3. Plugins → Lumen → fill in the Seerr address → Save.

## What it exposes

`GET /Lumen/Seerr` — for any signed-in user:

```json
{ "Url": "https://seerr.example.com" }
```

`Url` is `null` when the field is empty.

## Build

```sh
dotnet build Jellyfin.Plugin.Lumen -c Release
```

Requires Jellyfin 10.10 or newer. Releases are built by the `release` workflow, which also refreshes `manifest.json` on GitHub Pages.
