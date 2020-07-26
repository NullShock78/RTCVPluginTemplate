# RTCVPluginTemplate
Plugin template for the [Real Time Corruptor](https://github.com/ircluzar/RTCV)

## Setup
To set up first clone the repository with the following command:

```bash
git clone --recursive https://github.com/NullShock78/RTCVPluginTemplate.git
```

Open the project solution in `./Source` with Visual Studio 2019 and build the solution before starting to set up references.

You will need to rename the project and edit the assembly/default namespace in project settings, then refactor->rename the namespace in `Loader.cs`.

If the submodule version is behind, use the following command to update it, then rebuild the solution:
```bash
git submodule foreach git pull origin master 
```
