# Watchlist
Keep an eye on specific players joining your SCP:SL server(s). Add specific reasons to said players via the provided RA command and keep track of them all in text files created for you.
**This requires Galaxy119's DiscordIntegration to work.**
## Config Options
| Option | Type | Default | Description |
| --- | --- | --- | --- |
| debug | bool | false | Log debug messages |
| folder_path | string | \AppData\Roaming\EXILED\Plugins\Watchlist | Where all watchlist files are kept |
| ping_role_id | int | 0 | Discord role ID to ping whenever watched users join |
| log_channel | int | 0 | The channel the bot will make these announcements in |
## RA Commands
| Command name | Argument 1 | Argument 2 | Function |
| --- | --- | --- | --- |
| addwarn | Target's user ID | Reason | Add the target to your server watchlist with the reason provided |
| checkwarn | Target's user ID | `NONE` | Review the reasons the target is on the watchlist |
| remwarn | Target's user ID | Warning ID | Remove a specific reason for a target's watchlist. Removing the last reason will remove them from the watchlist |
