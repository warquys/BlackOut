# BlackOut
BlackOut plugin for SCP SL

# Description: 
The plugin turns off the lights for you randomly (you can configure it).

# Default config:
```yaml
BlackOut:
# ↓Indicates whether the plugin is enabled or not
  is_enabled: true
  # ↓Indicates whether the subtitles for cassie will be shown or not
  subtitles: true
  # ↓Specifies which cassie will be used when the light is turned off or on
  cassie_off_light: jam_70_5 warning .g5 warning ChaosInsurgency Hacked Complex jam_70_5 system . . Wait when malfunction will be repaired
  cassie_on_light: Facility .g5 back on operational .g6 mode
  # ↓Indicates whether cassie will be played when the lights are turned off. (false = will not. true = will be)
  cassie_on: true
  # ↓Minimum value, Specifies in which seconds a random time will be selected
  min_blackout_start_time: 60
  # ↓Maximum value
  max_blackout_start_time: 300
  # ↓Minimum value, Indicates how many seconds the light is turned off
  min_blackout_time: 30
  # ↓Maximum value
  max_blackout_time: 30
```
