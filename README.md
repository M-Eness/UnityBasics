# UnityBasics

This repository contains the source code for a simple Unity game project focusing on core gameplay mechanics. The project includes systems for enemy AI, player character management, a combat and health system, skill-based abilities, and a tower-building mechanic.

---

## Key Features

* **Enemy AI**: Uses `NavMeshAgent` for basic enemy pathfinding. Enemies pursue the player, with different behaviors for melee (Sword) and ranged (Archer) types.
* **Player & Character Management**: A character selection screen allows players to choose from different character types, each with unique stats defined by `ScriptableObject`. The selected character is then spawned in the main game scene.
* **Combat System**:
    * **Health & Resource Management**: Both players and enemies have a health system. Defeating enemies rewards players with a "blood" currency, managed by a Singleton pattern.
    * **Auto-Targeting**: The player character automatically targets the closest enemy, making combat fluid and dynamic.
    * **Projectiles**: Both players and enemies have projectile-based attacks.
* **Skills System**: A `SkillManager` allows for two types of player abilities, activated by hotkeys (Q, E).
    * **Area-of-Effect (AoE)**: The Meteor skill deals damage to all enemies within a specified radius.
    * **Targeted**: The Plane skill targets and damages a single enemy.
* **Tower Defense Elements**: Players can spend their "blood" currency to place towers on designated spots. Towers automatically target and attack the closest enemy within their range, adding a strategic layer to the game.
* **Game Flow**: The project includes a basic game flow with a `MainMenu`, `CharacterSelector`, and `GameOver` screen.

---

## Code Descriptions

The project is structured with C# scripts, each handling a specific part of the game logic.

### Character & Player Scripts

* **`CharacterData.cs`**: A `ScriptableObject` to define player character properties like damage, name, and prefab.
* **`CharacterSelector.cs`**: Manages the character selection UI, allowing players to choose a character before starting the game.
* **`CharacterSpawner.cs`**: Spawns the character chosen in the character selection scene when the main game starts.
* **`NavMeshMovement.cs`**: Controls player movement using a `NavMeshAgent`. The player moves to a point on the ground clicked by the mouse. It also handles the player's health and triggers the game over state upon death.
* **`PlayerMovement.cs`**: An alternative, older movement script that uses `transform.position` to move the player to a clicked target point.
* **`CharacterShoot.cs`**: Manages the player's primary attack, firing a `Bullet` at the `ClosestEnemy` at a set fire rate.
* **`Bullet.cs`**: The projectile fired by the player. It applies damage to enemies on collision.
* **`ClosestEnemy.cs`**: A utility script that finds the closest enemy to a specified transform, used for both player and tower targeting.
* **`SkillManager.cs`**: The core of the skill system. It handles skill selection (Q, E), manages cursor changes, and triggers the appropriate skill (`Meteor` or `Plane`) when the player clicks.
* **`Meteor.cs`**: A skill projectile that deals area damage to all enemies within its radius upon hitting the ground.
* **`Plane.cs`**: A skill projectile that flies towards and damages a targeted enemy.

### Enemy & Combat Scripts

* **`EnemyData.cs`**: A `ScriptableObject` to define different enemy types with properties like max health, speed, and attack power.
* **`EnemyHealthBar.cs`**: Manages an enemy's health, updates its UI health bar, and adds "blood" to the `BloodManager` when the enemy is defeated.
* **`EnemyMovement.cs`**: Implements the AI logic for enemy characters, controlling their movement based on their type (Archer stays at a distance, Sword closes in).
* **`SpawnEnemy.cs`**: Manages the spawning of enemies at random, safe distances from the player.
* **`ArcherShoot.cs`**: Handles the shooting mechanic for ranged enemies (Archers). It fires an `Arrow` at the player based on a timer or animation event.
* **`Arrow.cs`**: The projectile fired by the Archer enemy. It applies damage to the player on collision.

### UI & Management Scripts

* **`MainMenu.cs`**: Manages the main menu UI and scene transitions.
* **`GameOver.cs`**: Displays the "Game Over" screen, including the total "blood" collected, and allows the player to return to the main menu.
* **`BloodManager.cs`**: A Singleton script that acts as a global store for the "blood" currency, providing methods to add and spend it.

### Tower Scripts

* **`TowerTypes.cs`**: An enum defining different tower types, such as `Archer` and `Gunner`.
* **`TowerData.cs`**: A `ScriptableObject` to define the cost, damage, and type of different towers.
* **`TowerPlacer.cs`**: The primary script for the tower building mechanic. It handles placing towers on designated spots, checking if the player has enough "blood" to build.
* **`TowerPopupController.cs`**: Manages the UI popup that appears when the player attempts to build a tower, displaying its cost and type.
* **`TowerController.cs`**: The core of the tower's behavior. It finds the closest enemy within its range and fires projectiles at a set rate.
