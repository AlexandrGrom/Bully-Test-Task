
# Test task for Bully! developers

## Brief

Create a mobile app for Android or iOS in Unity or Unreal using reference and
short description below.

## Description:

AR app that uses the marker image given to present a 3D model of an old watch, 
its hands show current time and day of week. Watch has skins that include:
color of seconds hand, language of days, GMT timezone. There are two buttons
to cycle though skins. Clicking sound is used as feedback to button clicks.
The watch slowly rotates and small metal balls are popping out of its top
when you click it. To create an old-school look a camera effect is used: a
vignette with some grain noise (fullscreen effect).

## Hints

Use:

* Git for version control, a gitignore and git flow model;
* Vuforia/ARFoundation/OpenXR for AR experience and given marker;
* Unity: `ScriptableObject` for skins (material, day names, time offset);
* Unity: Custom inspector for skins to validate constrain: week can only have 7 days;
* Unity: C# interface for clickable objects;


## What is important in this task:

* Ability of candidate to quickly catch new things and learn on the fly;
* Strict following to feature requirements, as it were a real-life project;
* Attention to details;
* Code performance and architecture;
* Scene organization, asset names;
* Project structure, prefabs, hierarchy;
* Using correct asset serialization editor setting for git;
* Code style: variable names, regions, reasonable comments in English.

## What is not important

* No need to model watch - use standard 3D primitives provided by Engine;
* No need to match reference watch model 100% precise;
* No need to match materials and colors 100% precise;
* No need to use exact font;
* IDE used (better be [Vim](http://www.vim.org), ha).
* Extra features not listed in initial task or bonus.


## Bonus (for ninjas)

* `+1` Use pool manager singleton and reuse small spheres;
* `+3` Implement a screen space UI button to capture screenshot;
* `+4` Implement screenshot sharing on Android and iOS;
* `+10` Implement LUT color grading that work on mobile (i.e with no Texture3D);
* `+15` Create a wormhole effect under watch, that distorts real world camera feed (see reference).

## References

### Marker

![Marker](https://github.com/BullyEntertainment/test-task/raw/master/marker.jpg "Marker to use")

### Builds

[iOS App](https://github.com/BullyEntertainment/test-task/raw/master/builds/DevChallenge.ipa)

[Android App](https://github.com/BullyEntertainment/test-task/raw/master/builds/DevChallenge.apk)

### Unity Screens

![Editor](https://github.com/BullyEntertainment/test-task/raw/master/editor.png "Editor")
![App](https://github.com/BullyEntertainment/test-task/raw/master/screen.png "App")

### Video

[![AE in action](http://img.youtube.com/vi/sz8r3LHnoCU/0.jpg)](http://www.youtube.com/watch?v=sz8r3LHnoCU "AR In Action")

### Distortion 

![Distortion](http://i.ytimg.com/vi/Uef8FFNA-F0/hqdefault.jpg "Example of distortion")

## Submission

* Include full source code (Unity project)
* Include a brief decription of your decisions and challenges in project, as well as possible improvements.

(Ninjas can just use git repository and share the link)