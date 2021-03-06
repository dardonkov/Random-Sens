## Random-Sens by misterinsane
Disclaimer: This is a very much work-in-progress(WIP) tool, bugs are to be expected. More features and curves are also coming in the near future.
# Overview

This program is used to dynamically alter your effective mouse sensitivity according to a configurable pre-generated curve. It is mainly intended to be used while aim training,
in order to improve mouse control in general. It comes with a fully functional GUI that allows you to preview the sensitivity curves and follow the progress in real-time.
It aims to be a successor to the Sensitivity Randomizer by Whisper & El Bad - https://github.com/Whisperrr/SensitivityRandomizer
# WARNING
Recently Riot's Vanguard anticheat has started banning users for having the Interception driver installed. If you plan on playing Valorant it is advised to use the provided driver_uninstall.bat to remove the Interception driver.
# Installation

1. Download the latest release from the Github page - https://github.com/dardonkov/Random-Sens/releases

2. Before you start, you need to install the Interception driver which is used to capture/modify mouse input. If you have used Interaccel or the Sensitivity 
Randomizer by Whisper & El Bad, you already have the driver installed, so you can skip this step. If not, then you need to run driver_install.bat from the "driver-install" folder and restart your PC. Windows needs to reboot before the driver is usable. You can also install the driver following the instructions on the Interception Github page: https://github.com/oblitum/Interception

3. Start the Random-Sens.exe

# Main features and configuration
## Curve settings
The first group of settings dictates the type of curve you want the program to generate for you. The default setting is a curve generated by a 
LogNormal distribution - this is very similar to the Sensitivity Randomizer by Whisper & El Bad. 
 - "Max/Min Sensitivity multiplier" values determine the max/min limits of the generated curve
 - "Timestep" determines how often the sensitivity multiplier progresses along the curve or in simpler terms - how often your sensitivty will change. Default is 0.2 seconds or 200ms.
 - "Curve timestep" determines how often the curve generates a sensitivty point before interpolation. By default a new sensitivity point is generated every 5 seconds.
 - "Base Sensitivty" determines your base multiplier, changing is only supported with "Aggressive Curve"
 - "Spread" only affects the generation of the "LogNormal curve"
 - "Smoothing" is currently unused
*NB - not all parameters affect all curves, changes are coming.*
 - "Quick start/pause toggle" is a programmable hotkey to Pause/Start the randomizer. It can be used at any time, even when the program is minimized. Note: It pauses at the current sensivity multiplier and stops changing it, it does not restore your base sens. You can reassign this to any button by double clicking on the box, then pressing the key you wish to assign. Default is F6.
 - "Quick start/stop toggle" is a programmable hotkey to start or stop the randomizer. It can be used at any time, even when the program is minimized. This button resets your current sensitivity to 1 or your base sensitivity. You can reassign this to any button by double clicking on the box, then pressing the key you wish to assign. Default is F7.

## Curve information
Below that you can see statistics about the currently generated curve.
## Buttons
With the "Regenerate Curve" button the program will randomly generate and visualize a roughly 5min long sensitivity curve. 
- "Start" button will start randomizing you sensitivity output. In the interface, you can track in real-time the sens multiplier and the current curve completion. Important to note is that once the current curve reaches its end, a new one will be automatically generated. The randomizer will not stop on it's own.
and will automatically start over. 
- "Pause" button will pause at the current sensitivity multiplier like the start/stop hotkey.
- "Save default settings" button will save the current settings as defaults so that next time you start the tool, 
they will be loaded automatically.
- "Restore default settings" button will restore the default curve settings. It is advised to save your settings
once you've found what you are comfortable with. If you close the tool without saving, the next time you start it up, your settings will be reset.
## Other 
![Alt text](https://i.ibb.co/R9XDfzq/Random-sens-0-2.png "Random-sens")
