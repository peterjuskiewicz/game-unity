# Design and Implementation

## Concept

Before starting this project I went to look for inspirations in Victoria and Albert Museum - Video Game Exhibiton. There were several games presented and all of them shared similar objectives: collecting items, killing or avoiding enemies and reaching destination. I have decided to build a game that will implement those 3 functionalities () using basic games objects.

## Requirements

1. Player can navigate the player object by using the keyboard and mouse
2. The game is implemented in TPP
3. There are enemies objects that player has to avoid
4. There are collectables that player can collect
5. There is a destination that player has to reach in order do win the game
6. If player falls of the plane, he's moved to the spawn point.
7. If an enemy object collides with the player object, the game is over
8. If the player collects a collectable, the number of points increses by 1
9. If the player reaches the destination, he wins the game

## Assets requirements

In this game projects only basic game objects are used: spheres, planes, cubes and capsules. Textures such as lava, grass, rocks and Skybox have been downloaded from the Asstets Store. All the basics objects can be easily replaced by assets. There are following objects in the game:

1. Player cube with white spot light attached and grass texture
2. Collectable capsules (5) with green halo effect
3. Enemy spheres (2) with red poin light attached and lava texture
4. Destination sphere (only collider) and the light pointing to the destination
5. Floor plane with grass texture, being walkable navigation area
6. Main camera following the player
7. Dimmed directional light

## Implementation

1. Camera behaviour is implemented to simulate third person perspective. Camera is looking at the target object (Player) and follows the changing position of the object.
2. There is collision detection functionality - detect collistion with enemy, collectable and destination objects and call different functions (add points, win game, lose game) depending on which event has been triggered.
3. Player movement is implemented using turning and move methods.
4. Respawning of the player is implemented in the event of falling of the plane. There is an additional collider underneath the actual floor to detect the falling object.
5. There are UI elements displaying current state of the game (playing, win, game over) and number of collectables collected.

|Object|Component|My Activity|Comments|
|---|---|---|---|
|   |   |   |   |
|   |   |   |   |
|   |   |   |   |




