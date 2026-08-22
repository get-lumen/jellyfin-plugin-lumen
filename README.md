# Jellyfin plugin: Ward

Lets the [Ward](https://github.com/OrangeJuiced/Ward) app find your Seerr automatically. Set the Seerr address once in Jellyfin; every user who signs in to Ward gets requests without typing anything.

## Install

1. Jellyfin dashboard → Plugins → Repositories → add
   `https://orangejuiced.github.io/jellyfin-plugin-ward/manifest.json`
2. Catalog → Ward → Install, restart Jellyfin.
3. Plugins → Ward → fill in the Seerr address → Save.

## What it exposes

`GET /Ward/Seerr` — for any signed-in user:

```json
{ "Url": "https://seerr.example.com" }
```

`Url` is `null` when the field is empty.

## Build

```sh
dotnet build Jellyfin.Plugin.Ward -c Release
```

Requires Jellyfin 10.10 or newer. Releases are built by the `release` workflow, which also refreshes `manifest.json` on GitHub Pages.
