# GrandMeridian (minimal Unity project)

This is a minimal Unity project scaffold for cloud build testing.

Files included:
- Assets/Scenes/MainScene.unity
- Assets/Scripts/PlayerController.cs
- ProjectSettings/ProjectSettings.asset
- Packages/manifest.json
- Packages/packages-lock.json

How to build:
1. Make sure these files are in your repository root as shown.
2. In Unity Cloud Build: Branch = `main`. Leave project subfolder blank unless you put the Unity files in a subfolder.
3. Choose a Unity version from Cloud Build (prefer a 2021.3.x LTS or 2022.x LTS that Cloud Build shows).
4. Android SDK: choose `Android SDK 33` (safe default).
5. Start build. If build fails, copy the build error lines and send screenshot.
6. 
