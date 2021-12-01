# Resource-Management
Resource Management simulation project

**Added programming design Funtionalities**

Base Singleton class for all the Singletons used.
Multiple managers instead of one GameManager/MainManager. All Managers are lazy instantiated by the game manager itself.
All managers live within a "Persistent Object" GameObject which is a Singleton by itself.
Interface Saveable added and every class impleting it will be saved.

**Added GamePlay Funtionalities**

The truck will move away to unload the resources when the base is full.
HUD displays the current resource amount to maximum space available in the base ratio.
