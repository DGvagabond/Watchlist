using System;
using Exiled.API.Features;
using Exiled.API.Enums;
using Player = Exiled.Events.Handlers.Player;

namespace Watchlist
{
    public class Watchlist : Plugin<Config>
    {
        internal static Watchlist Instance { get; } = new Watchlist();
        private Watchlist()
        {

        }

        public override PluginPriority Priority { get; } = PluginPriority.Lowest;

        public override string Author { get; } = "DGvagabond";
        public override string Name { get; } = "Watchlist";
        public override Version Version { get; } = new Version(1, 0, 0, 0);
        public override Version RequiredExiledVersion { get; } = new Version(2, 1, 7);

        public Methods Methods;
        public EventHandlers Handler;
        public static Watchlist Singleton;


        public override void OnEnabled()
        {
            try
            {
                base.OnEnabled();
                RegisterEvents();
            }

            catch (Exception e)
            {
                Log.Error($"There was an error loading the plugin: {e}");
            }
        }

        public override void OnDisabled()
        {
            base.OnDisabled();
            UnregisterEvents();
        }

        public void RegisterEvents()
        {
            Singleton = this;
            Methods = new Methods(this);
            Handler = new EventHandlers(this);

            Player.Joined += Handler.OnJoin;
        }
        public void UnregisterEvents()
        {
            Player.Joined -= Handler.OnJoin;

            Handler = null;
            Methods = null;
        }
    }
}
