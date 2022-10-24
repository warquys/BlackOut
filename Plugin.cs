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
    public class Plugin : Plugin<Config>
    {
        public override string Prefix => "BlackOut";
        public override string Name => "BlackOut";
        public override string Author => "Rysik5318, fix by VT";
        public override Version Version { get; } = new Version(2, 0, 0);

        
        public EventHandler EventHandler { get; private set; }

        public override void OnEnabled()
        {
            base.OnEnabled();
            if (EventHandler == null) 
                EventHandler = new EventHandler(Config);
            else 
                EventHandler.AttachEvent();
        }

        public override void OnDisabled()
        {
            EventHandler.DetachEvent();
            base.OnDisabled();
        }

        
    }
}
