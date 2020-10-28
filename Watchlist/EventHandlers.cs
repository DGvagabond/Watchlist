using System.IO;
using DiscordIntegration_Plugin;
using Exiled.Events.EventArgs;

namespace Watchlist
{
    public class EventHandlers
    {
        private readonly Watchlist plugin;
        public EventHandlers(Watchlist plugin) => this.plugin = plugin;

        
        public void OnJoin(JoinedEventArgs ev)
        {
            string path = Path.Combine(Watchlist.Instance.Config.FolderPath, ev.Player.UserId);

            if (File.Exists(path))
            {
                if (ev.Player.DoNotTrack)
                {
                    if (Watchlist.Instance.Config.PingRoleId != 0 && Watchlist.Instance.Config.PingRoleId.ToString().Length == 18)
                        ProcessSTT.SendData($"<@&{Watchlist.Instance.Config.PingRoleId}> `A watched user has joined`\n{ev.Player.Nickname} ({ev.Player.UserId})\n============================", (ulong)Watchlist.Instance.Config.LogChannel);
                    else
                        ProcessSTT.SendData($"`A watched user has joined`\n{ev.Player.Nickname} ({ev.Player.UserId})\n============================", (ulong)Watchlist.Instance.Config.LogChannel);
                }
                if (!ev.Player.DoNotTrack)
                {
                    if (Watchlist.Instance.Config.PingRoleId != 0 && Watchlist.Instance.Config.PingRoleId.ToString().Length == 18)
                        ProcessSTT.SendData($"<@&{Watchlist.Instance.Config.PingRoleId}> `A watched user has joined`\n{ev.Player.Nickname} ({ev.Player.UserId}) ||{ev.Player.IPAddress}||\n============================", (ulong)Watchlist.Instance.Config.LogChannel);
                    else
                        ProcessSTT.SendData($"`A watched user has joined`\n{ev.Player.Nickname} ({ev.Player.UserId}) ||{ev.Player.IPAddress}||\n============================", (ulong)Watchlist.Instance.Config.LogChannel);
                }
            }
        }
    }
}