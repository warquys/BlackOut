using Exiled.API.Enums;
using Exiled.API.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackOut
{
    public class Config : IConfig
    {
        [Description("↓Indicates whether the plugin is enabled or not")]
        public bool IsEnabled { get; set; } = true;

        [Description("↓Indicates whether the subtitles for cassie will be shown or not")]
        public bool Subtitles { get; set; } = true;

        [Description("↓Specifies which cassie will be used when the light is turned off or on")]
        public string Cassie_OffLight { get; set; } = "jam_70_5 warning .g5 warning ChaosInsurgency Hacked Complex jam_70_5 system . . Wait when malfunction will be repaired";
        public string Cassie_OnLight { get; set; } = "Facility .g5 back on operational .g6 mode";
        
        [Description("↓Indicates whether cassie will be played when the lights are turned off. (false = will not. true = will be)")]
        public bool Cassie_On { get; set; } = true;

        [Description("↓Minimum value,  Specifies in which seconds a random time will be selected.")]
        public int Min_Blackout_Start_Time { get; set; } = 60;
        
        [Description("↓Maximum value")]
        public int Max_Blackout_Start_Time { get; set; } = 300;

        [Description("↓Minimum value, Indicates how many seconds the light is turned off.")]
        public int Min_Blackout_Time { get; set; } = 30;
        
        [Description("↓Maximum value")]
        public int Max_Blackout_Time { get; set; } = 35;

    }
}
