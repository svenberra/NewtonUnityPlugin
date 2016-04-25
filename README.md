
Compiling NewtonUnityPlugin
===========================

# READ THIS!
### Plugin is being rebuilt from scratch, this time using Swig-generated wrapper.
There will be limited functionality for a while because of this.

## Windows

Windows only for now.
It should work on any other OS too, but the project is only a few days old so only Windows for now. 

Just open the solution file (NewtonUnityPlugin.sln) and build. (Visual Studio 2015)

For now, choose Release and x64

# NewtonWrapper
You need to download and build the Newton Dynamics Library first.
https://github.com/MADEAPPS/newton-dynamics/

Adjust the include directories and linker paths in the NewtonWrapper project to match the location where you installed Newton.

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

This dll goes directly into your Unity project folder, not inside the Assets folder.
If you place it in the assets folder, Unity will think it's a native Unity plugin, which it isn't.

If you build the Newton Dynamics libraries as dynamic libs instead of static libs you will also need to copy the following dlls to the same
folder as the NewtonWrapper.dll
* dContainers.dll
* dJointLibrary.dll
* newton.dll

**Note though!** NewtonPlugin requires the newton.dll, but the NewtonWrapper might be able to be statically linked(haven't tried yet).

The plugin is compiled as a 64-bit library by default so remember to compile Newton as 64-bit as well.

When Unity detects the plugin you will need to tell Unity if it's 64-bit or not.
Just click on the plugin in the Assets view and check the 64-bit option.

## One very important thing
This plugin is based on using Unity GameObjects that under the hood handles unmanaged Newton objects.
In Unity GameObjects are by default initiated in complete random order.
Therefor, if a Rigid Body is connected to a Joint it's important that the Body GameObject is created before the Joint GameObject.

To solve this we have to control in which order the GameObjects are initiated when the scene is loaded.
 
Unity let you do this by using something called "Script Execution Order".
So currently when you create a new Unity Project, after adding the NewtonPlugin you must go to Edit -> Project Settings -> Script Execution Order.

Then make sure the following GameObjects scripts are execute AFTER the DefaultTime.
* NewtonPlugin.NewtonBallAndSocket
* NewtonPlugin.NewtonHinge
* NewtonPlugin.NewtonRollingFriction

I'm working on automating this because it's an important step that will cause the application to crash if not done.

Demo
====

If you want to test without compiling or see how to use the GameObjects, download the following Unity Project.
http://www.svenberra.net/NewtonDemo.zip





