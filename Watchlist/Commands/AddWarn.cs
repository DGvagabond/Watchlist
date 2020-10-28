using System;
using System.Linq;
using CommandSystem;

namespace Watchlist.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class AddWarn : ICommand
    {
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (arguments.Count < 2)
            {
                response = "Invalid number of arguments. Provide a user ID and a reason.";

                return false;
            }

            string userId = arguments.At(0);

            if (!userId.Contains("@"))
            {
                response = "Invalid user ID";

                return false;
            }

            string reason = arguments.Where(a => a != arguments.At(0)).ToString();

            if (Watchlist.Singleton.Methods.AddWarning(((CommandSender)sender).Nickname, userId, reason))
            {
                response = $"Now watching {userId}.";

                return true;
            }
            else
            {
                response = "Unable to add warning. Report this error to the server manager.";

                return false;
            }
        }

        public string Command { get; } = "addwarn";
        public string[] Aliases { get; } = new[] { "awarn" };
        public string Description { get; } = "Add a warning.";
    }
}