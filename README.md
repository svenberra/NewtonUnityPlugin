
Compiling NewtonUnityPlugin
===========================

# READ THIS!
### Plugin is being rebuilt from scratch, this time using Swig-generated wrapper.
There will be limited functionality for a while because of this.

## Windows

Windows only for now.
It should work on any other OS too, but the project is new so only Windows for now. 

Just open the solution file (NewtonUnityPlugin.sln) and build. (Visual Studio 2015)

For now, choose Release and x64

# NewtonWrapper
You need to clone and build the Newton Dynamics Library first.
https://github.com/MADEAPPS/newton-dynamics/

Create an environment variable named NEWTON_DYNAMICS that match the location where you installed Newton.

# NewtonPlugin
NewtonPlugin requires a reference to the assembly UnityEngine.dll which you will find where Unity 3D is installed.
<Unity Installdir>\Editor\Data\Managed\UnityEngine.dll

Using NewtonUnityPlugin
=======================

After building the projects there will be two dlls in the PluginBinaries folder.

* NewtonPlugin.dll
This is the managed Unity plugin which must be added to your Unity project.
In your unity project Assets folder, create a subfolder named Plugins and put it there.  

* NewtonWrapper.dll
This dll contains wrapper functions the NewtonPlugin.dll uses to access certains c++ objects in Newton Dynamics that
a .NET dll can't normally access.

The plugin is compiled as a 64-bit library by default so remember to compile Newton as 64-bit as well.

When Unity detects the plugin you will need to tell Unity if it's 64-bit or not.
Just click on the plugin in the Assets view and check the 64-bit option.

Demo
====

Unity demos and examples can be found in the Demos folder.[Soon, under construction right now]




