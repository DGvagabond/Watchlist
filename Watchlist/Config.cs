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
        public int PingRoleId { get; set; } = 0;
        public int LogChannel { get; set; } = 0;
    }
}