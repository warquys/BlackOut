using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.Events.EventArgs;
using MEC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackOut
{
    class Plugin : Plugin<Config>
    {
        public override string Prefix => "BlackOut";
        public override string Name => "BlackOut";
        public override string Author => "Rysik5318";

        public static Plugin plugin;
        public override Version Version { get; } = new Version(1, 1, 7);

        bool BlackoutOFF = false;

        bool RoundStart = false;

        public override void OnEnabled()
        {
            plugin = this;
            base.OnEnabled();
            Exiled.Events.Handlers.Server.RoundStarted += OnRoundStart;
        }

        public override void OnDisabled()
        {
            plugin = null;
            Exiled.Events.Handlers.Server.RoundStarted -= OnRoundStart;
            base.OnDisabled();
        }

        private void OnRoundStart()
        {
            Random rnd = new Random();
            BlackoutOFF = false;
            RoundStart = true;
            Timing.CallDelayed(rnd.Next(Config.MinBlackoutStartTime, Config.MaxBlackoutStartTime), () => Blackout());
        }
        private void Blackout()
        {
            if (RoundStart)
            {
                if (!BlackoutOFF)
                {
                        IEnumerable<ZoneType> zoneTypes = new List<ZoneType>() { ZoneType.Entrance, ZoneType.HeavyContainment, ZoneType.LightContainment };
                        Random rnd = new Random();
                        float time = rnd.Next(Config.MinBlackoutTime, Config.MaxBlackoutTime);
                        Map.TurnOffAllLights(time, ZoneType.Entrance);
                        Map.TurnOffAllLights(time, ZoneType.HeavyContainment);
                        Map.TurnOffAllLights(time, ZoneType.LightContainment);
                        if (Config.offCassie)
                        {
                            Timing.CallDelayed(3f, () => Cassie.Message(Config.CassieLight, false, true, Config.Subtitles));
                        }
                        else if (!Config.offCassie);
                        Timing.CallDelayed(rnd.Next(Config.MinBlackoutStartTime, Config.MaxBlackoutStartTime), () => Blackout());
                        BlackoutOFF = true;
                }
            }
        }
    }
}
