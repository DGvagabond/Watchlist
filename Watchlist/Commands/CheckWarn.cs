using System;
using CommandSystem;

namespace Watchlist.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class CheckWarn : ICommand
    {
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            string userId = arguments.At(0);
            response = Watchlist.Singleton.Methods.CheckWarning(userId);

            return true;
        }

        public string Command { get; } = "checkwarn";
        public string[] Aliases { get; } = new[] { "cwarn" };
        public string Description { get; } = "Check a SteamID for warnings.";
    }
}