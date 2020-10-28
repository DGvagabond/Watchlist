using Exiled.API.Features;

namespace TomHasSmoothBrain
{
    public class Plugin : Plugin<Config>
    {
        public EventHandlers Handler;
        public Methods Methods;
        public static Plugin Singleton;
        
        public override void OnEnabled()
        {
            Singleton = this;
            Methods = new Methods(this);
            Handler = new EventHandlers(this);
            Exiled.Events.Handlers.Player.Joined += Handler.OnJoin; 
            base.OnEnabled();
        }
    }
}