# Unity2022.7.3-URP-Base-Project
A base project setup that can be adapted to your needs. 
Download as zip and work away!

This is meant as a starting point to speed up new projects.
Some of the controllers have debugging/testing code in the update methods. I recommend you delete that :)
More info to come!

Note: This is still a work in progress.
---------------------------------------
Key scripts (Static Controllers)
---------------------------------------
NOTE: These controllers should ideally not subscribe to eachothers events. They should explicitly call functions from 
other controllers if needed. This mitigates any issues with class initialization / race conditions on startup.

GameController
  - Controls the state of the game. Base script contains GAMESTATE.RUNNING and GAMESTATE.PAUSED

MusicController
  - Controls the background music of the game
  - Allows for crossfading of two tracks
  - Uses GameSettingsSO (Scriptable Object) to control track volume
  - Can be extended to allow for individual tracks to have max volume modifiers to account for different tracks being exported at different volumes.

InputController
  - Uses the Unity new Input System
  - Switches between Menu Controls and Game Controls
  - Game controls only included a button to pause/unpause the game (brings up the settings menu)
  - Works with Keyboard and Gamepad
  - Can be extended to include additional control schemes

SceneController
  - Triggers a transition screen to fade in, loads the new scene, then the transition screen fades out
  - Would be more idea to adjust this to have this class take reference to a transition interface, this would
    make it easier to replace the transition screen with an animation or some other object.
  - Extend with how ever many scenes you need! 
