### Random-Sens by misterinsane
Disclaimer: This is a very much work-in-progress(WIP) tool, bugs are to be expected. More features and curves are also coming in the near future.
## Overview

This program is used to dynamically alter your effective mouse sensitivity according to a configurable pre-generated curve. It is mainly intended to be used while aim training,
in order to improve mouse control in general. It comes with a fully functional GUI that allows you to preview the sensitivity curves and follow the progress in real-time.
It aims to be a successor to the Sensitivity Randomizer by Whisper & El Bad - https://github.com/Whisperrr/SensitivityRandomizer

## Installation

1. Download the latest release from the Github page - https://github.com/dardonkov/Random-Sens/releases
*always check newer releases*

2. Before you start, you need to install the Interception driver which is used to capture/modify mouse input. If you have used Interaccel or the Sensitivity 
Randomizer by Whisper & El Bad, you already have the driver installed, so you can skip this step. If not, then you need to run the install-interception.exe 
as Administrator and restart Windows. You can also install the Interception driver from the Github page: https://github.com/oblitum/Interception

3. Start the Random-Sens.exe

## Main features and configuration

The first thing you can choose is the type of curve you want the program to generate for you. The default setting is a curve generated by a 
LogNormal distribution - this is similar to the Sensitivity Randomizer by Whisper & El Bad. You can also modify the maximum and minimum values
and other parameters for the curve. NB - not all parameters affect all curves, changes are coming. With the "Regenerate Curve" button the program 
will randomly generate and visualize a roughly 5min long sensitivity curve. Below you can see some statistics about the current curve. When you press 
the "Start" button, the program will start randomizing you sensitivity output. By default it progresses the curve every 0.2 seconds, i.e. it changes 
your sensitivity every 0.2 seconds. In the interface, you can track in real-time the sens multiplier and the current curve completion. Using the "Pause"
button you can pause at the current sensitivity multiplier. Once the current curve reaches its end, a new one will be generated with the current settings
and will automatically start over. The "Save default settings" button will save the current settings as defaults so that next time you start the tool, 
they will be loaded automatically. The "Restore default settings" button will restore the default curve settings. It is advised to save your settings
once you've found what you are comfortable with. If you close the tool without saving, next time it starts up your settings will be reset.

![Alt text](https://i.ibb.co/k5VbQf8/Random-sens.png "Random-sens")
