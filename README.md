# The Mystery Land

A mobile game project inspired by Survivor Z, focusing on core mechanics.

## Features

* 3rd-person player controller with locomotion animations.
* Camera system replicating Survivor Z's style.
* Random loot spawner (coins and gems).
* Player health system with a UI health bar.
* Save/load system for collected currency.
* Basic menu scene with Play and Quit buttons.

## Setup Instructions

1. **Prerequisites:**
    * Unity Engine (version used for development): 2022.3.19f1
    * Joystick Pack (https://assetstore.unity.com/packages/tools/input-management/joystick-pack-107631)
2. **Clone Repository:**
    ```bash
    git clone https://github.com/Mysharsh/The-Mystery-Place.git
    ```
3. **Open in Unity:** Open the cloned project directory in the Unity Editor.
4. **Run Gameplay Scene:** The main gameplay is in the 'MenuScene'.

## Controls

* **Movement:** Use the Floating joystick (configurable in the Input Manager) to control the player's direction and speed."


## Project Structure

* **Scenes:**
    * `MenuScene`: The initial menu.
    * `GameplayScene`: The core gameplay.
* **Scripts:**
    * `PlayerController.cs` 
    * `CameraController.cs`
    * `LootSpawner.cs`
    * `HealthManager.cs`
    * `UIManager.cs`
    * `SaveDataManager.cs`
* **Prefabs:**
   * Player
   * Loot Items (Coin, Gem)
   * Health Bar
   * UI Elements

## Known Issues



## Contributing

This project was developed as a short assignment and is not open for external contributions at this time.

## Credits 

* **Unity Asset Store:**
    * Joystick Pack (https://assetstore.unity.com/packages/tools/input-management/joystick-pack-107631) by tsoj
    * Low Poly Animated Character Pack (https://assetstore.unity.com/packages/3d/characters/low-poly-animated-character-pack-184599) by ABC Studios

* **Other Sources:**
    * Mixamo (https://www.mixamo.com/) for character animations.
