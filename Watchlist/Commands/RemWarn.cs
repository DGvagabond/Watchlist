using System;
using CommandSystem;

namespace Watchlist.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class RemWarn : ICommand
    {
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (arguments.Count < 2)
            {
                response = "Invalid number of arguments. You must provide a user ID and a WarningID.";

                return false;
            }

            if (!int.TryParse(arguments.At(1), out int id))
            {
                response = "Unable to parse warning ID. Not a number.";

                return false;
            }

            string userId = arguments.At(0);

            if (Watchlist.Singleton.Methods.RemoveWarning(userId, id))
            {
                response = "Warning removed.";

                return true;
            }
            else
            {
                response = "Unable to remove warning.";

                return false;
            }
        }

        public string Command { get; } = "remwarn";
        public string[] Aliases { get; } = new[] { "rwarn" };
        public string Description { get; } = "Remove a warning";
    }
}