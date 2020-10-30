using Exiled.API.Features;
using Exiled.API.Interfaces;
using System.IO;

namespace Watchlist
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; }
        public string FolderPath { get; set; }= Path.Combine(Paths.Plugins, "Watchlist");
        public long PingRoleId { get; set; } = 0;
        public long LogChannel { get; set; } = 0;
    }
}
