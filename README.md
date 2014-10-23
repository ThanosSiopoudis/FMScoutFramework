# FMScoutFramework

FMScoutFramework is a C#.NET/Mono Framework that enables you to create your own assistant tools / editors for Football Manager. It supports both FM2014 and FM2015

## Project Setup

Clone the project in your favourite github client
You will need [MonoDevelop](http://monodevelop.com) if you develop your application for all platforms (Windows, OS X, Linux) or Microsoft Visual Studio if you develop just for windows. The client requirements will be the Mono framework for apps developed in MonoDevelop, or the .NET Framework for Visual Studio apps.

### Monodevelop Settings
1. Create your new MonoDevelop Solution
2. You can clone this repository and add it as a submodule in your own git tree, or just checkout the latest.
3. Add the FMScoutFramework project to your solution.
4. Expand your own project, and right click on `References`
5. Select `Edit References`
6. Click the `Projects` tab and tick the checkbox next to `FMScoutFramework`
7. Click `OK`
8. Right click on the `FMScoutFramework` Project
9. Click on `Options`
10. Select `Compiler` from the Menu
11. In the `Define Symbols` entry, enter `MAC` for OS X, `LINUX` for Linux or `WINDOWS` for windows.
12. You are now ready to start developing your app. Look further down for code

### Microsoft Visual Studio Settings
1. Create your new Visual Studio Solution
2. You can clone this repository and add it as a submodule in your own git tree, or just checkout the latest.
3. Add the FMScoutFramework project to your solution.
4. Expand your own project and right click on `References`
5. Click `Add Reference`
6. Click the `Projects` tab, under `Solution` and tick the checkbox next to `FMScoutFramework`
7. Click `OK`
8. Right click on the `FMScoutFramework` Project
9. Click on `Properties`
10. Select `Build` from the menu on the left
11. In the `Conditional Compilation Symbols` textbox, enter `WINDOWS;`
12. You are now ready to start developing your app. Look further down for code

##### Example Code

The following code is an example for a simple Windows Forms application and another for Mono
First, include the necessary framework headers:
```csharp
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using FMScoutFramework.Core;
using FMScoutFramework.Core.Entities.InGame;
```

In your class, create a new public variable:
```csharp
public FMCore fmCore = new FMCore (FMScoutFramework.Core.Entities.DatabaseModeEnum.Realtime);
```

First, create a new method that will be asynchronously called by the framework when loading is finished:
```csharp
public void GameLoaded() {
  Debug.WriteLine("Loading Finished");
}
```

Then, in your action callback method (from a button, or a menu for example) use the following code:
```csharp
fmcore.GameLoaded += new Action(GameLoaded);
new Action(() => fmCore.LoadData()).BeginInvoke((s) => { }, null);
```

That's it! You can now query the data, with simple Linq queries! Amazing, eh? Here's an example, to look for "Bar":
```csharp
var clubs = (from c in fmCore.Clubs
				     where c.Name.Contains ("Bar")
			       select c).Take (100).ToList ();
```

## Deploying

### _How to deploy_

## Troubleshooting & Useful Tools

_Examples of common tasks_

> e.g.
> 
> - How to make curl requests while authenticated via oauth.
> - How to monitor background jobs.
> - How to run the app through a proxy.

## Contributing changes

- Please open github issues

## License

FMScoutFramework is released under the GNU General Public License v2.0
Please read the LICENSE file for a full version of the License
