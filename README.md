
# Compiling NewtonUnityPlugin

Windows supported only for now.
It should work on any other OS too, but the project is new so only Windows for now. 

## Step 1, Download and build the Newton Dynamics Library 

The best option is to clone Newton from the following repository.
https://github.com/MADEAPPS/newton-dynamics/

Open the following solution file.
<newton install dir >\packages\projects\visualStudio_2015_static_mt\build.sln

Choose Release & x64 and build the solution.

Finally, create an environment variable named NEWTON_DYNAMICS that points to the location where you installed Newton.

## Step 2, Download and build the NewtonUnityPlugin
https://github.com/svenberra/NewtonUnityPlugin

Just open the solution file (NewtonUnityPlugin.sln) and build. (Visual Studio 2015)
For now, choose Release and x64

### NewtonPlugin & NewtonPluginEditor
NewtonPlugin & NewtonPluginEditor requires references to the assemblies UnityEngine.dll & UnityEditor.dll which you will find where Unity 3D is installed.
<Unity Installdir>\Editor\Data\Managed\
Copy them over to the folder PluginBin to make sure you compile the plugin with the same dlls Unity are using. 


# Using NewtonUnityPlugin

After building the projects there will be three dlls in the PluginBin folder.

* NewtonPlugin.dll
This managed dll(assembly) contains the runtime components(world, colliders, bodies and joints).
In your unity project Assets folder, create a subfolder named Plugins and put it there.  

* NewtonPluginEditor.dll
This is another managed dll that contain editors for the above components.
This plugin goes into a subfolder called Editor under the Assets folder.  

* NewtonWrapper.dll
This native dll contains the SWIG-generated C-functions that the managed dlls above use to access the Newton API.
This plugin goes into the same folder as NewtonPlugin.dll

The plugins are compiled as 64-bit libraries by default so remember to compile Newton as 64-bit as well.

When Unity detects the plugins you will need to tell Unity if it's 64-bit or not.
Just click on the plugin in the Assets view and check the 64-bit option.

Demo
====

Demos and examples can be found in the Demos folder.




