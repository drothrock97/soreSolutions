# soreSolutions
This repository was created for the Sore Solutions Pressure Sore Alert Device. RIT MSD P20018.

Some useful insights for when modifying the code:

Most, if not all changes will be made to the formMain.Designer.cs and formMain.cs files.
The formMain.Designer.cs file is used for adding/removing user inputs or timers and such that will be seen on the application screen.

The formMain.cs file is where all calculations and analyses occur.

Simulation profiles are found in the MattressDevice.cs file.
To use a simulation profile, set the input port as the profile name.
SIM produces random values for all locations.
SETSIM produces specified values in a square shape.
BSIM produces a more anitomically relavent signal.

To see changes reflected in the application, you must first build the solution.
Afterwards, the application can be found in the SensingTexAPI>bin>Debug folder.


# Known Bugs
1. After calculating pressure sore onset time, first minute is not counted when counting down.
2. Average localized maximum isn't accurate when there is a block of equal PSI values. This is because of how it is calculated and shouldn't be an issue in real world because it is unlikely that there will be a block of equal pressure values.
