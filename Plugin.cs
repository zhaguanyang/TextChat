using Exiled.API.Enums;
using Exiled.API.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Exiled.Events;
using Exiled.Loader;
using Server = Exiled.Events.Handlers.Server;

namespace SCPChat
{
    public class Plugin : Plugin<Config>
    {
        public override string Name => typeof(Plugin).Namespace;
        public override string Author => "x3rt";
        public override Version RequiredExiledVersion { get; } = new Version(5, 2, 0);
        public override Version Version { get; } = new Version(1, 1, 0);
        public override PluginPriority Priority { get; } = PluginPriority.Last;

        private readonly EventHandlers _eventHandlers = new EventHandlers();
        internal static Config SharedConfig { get; set; }
        internal static List<string> ChatMessages { get; set; } = new List<string>();

        public Plugin()
        {
        }

        public override void OnEnabled()
        {
            Assembly assembly = Loader.Plugins.FirstOrDefault(pl => pl.Name == "AdvancedHints")?.Assembly;
            if (assembly == null)
            {
                Log.Error("AdvancedHints not found! SCPChat will not work! Download it at https://github.com/BuildBoy12/AdvancedHints/releases and place it in your Exiled/Plugins folder");
                return;
            }

            SharedConfig = Config;
            RegisterEvents();
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            UnregisterEvents();
            base.OnDisabled();
        }

        private void RegisterEvents()
        {
            Server.WaitingForPlayers += _eventHandlers.OnWaitingForPlayers;
        }

        private void UnregisterEvents()
        {
            Server.WaitingForPlayers -= _eventHandlers.OnWaitingForPlayers;
        }
    }
}