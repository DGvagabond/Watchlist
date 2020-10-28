using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Discord;
using Discord.Commands;
using Exiled.API.Features;
using Utf8Json.Resolvers.Internal;

namespace Watchlist
{
    public class Methods
    {
        private readonly Watchlist plugin;
        public Methods(Watchlist plugin) => this.plugin = plugin;
        public bool AddWarning(string issuer, string userid, string reason)
        {
            try
            {
                string path = Path.Combine(plugin.Config.FolderPath, userid);

                if (File.Exists(path))
                {
                    File.AppendAllText(path, reason + $"Issued by {issuer}");
                }
                else
                {
                    File.WriteAllText(path, reason + $"Issued by {issuer}");
                }

                return true;
            }
            catch (Exception e)
            {
                Log.Error($"AddWarning: {e}");
                Log.Debug($"AddWarning: {e.StackTrace}", plugin.Config.Debug);

                return false;
            }
        }

        public bool RemoveWarning(string userId, int warnId)
        {
            try
            {
                string path = Path.Combine(plugin.Config.FolderPath, userId);

                if (!File.Exists(path))
                    return false;


                List<string> read = File.ReadAllLines(path).ToList();

                read.Remove(read[warnId - 1]);

                File.Delete(path);
                
                if (read.Count > 0)
                    File.WriteAllLines(path, read);

                return true;
            }
            catch (Exception e)
            {
                Log.Error($"RemWarn: {e}");
                Log.Debug($"RemWarn: {e.StackTrace}", plugin.Config.Debug);
                return false;
            }
        }

        public string CheckWarning(string userId)
        {
            string path = Path.Combine(plugin.Config.FolderPath, userId);

            if (!File.Exists(path))
                return "Not Watched.";

            string[] read = File.ReadAllLines(path);

            string info = string.Empty;
            int counter = 0;
            foreach (string s in read)
            {
                counter++;
                info += $"{counter}. {s}\n";
            }

            return info;
        }
    }
}