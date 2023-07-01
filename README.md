# Fox_Adventure_Game
# Group 04, Ellen Weiß, Luisa Abels, Isabella del Pozo


## Game Description


In this game you play a little fox in a mountain landscape. 
In the environment on the mountain you find different levels and you want to get to the top to build your fire place. 
On your way you have to overcome obstacles and have to collect items, otherwise you will not be able to reach the top. 


## Features of Our Game

Main Menu

    - Play Button: start the game
    - Settings Button: turn audio on/off 
        - with Back Button to go back to the main menu
    - Quit Button: Quits the game when it is built

Music

    - continuous background sound 
    - item pickup sound
    - barking sound
    - audio manager attached to main menu

Player can:

    - walk at normal pace
    - run
    - jump
    - double jump
    - move into all directions
    - rotate into direction it walks (where camera is faced)
    - collect items (normal game objects that have a special tag)
    - open an inventory
    - add items to inventory
    - move items in inventory
    - run, jump and walk animations included logically
    - rotate through animations when idle
    - bark (with animation)

Camera

    - cinemachine camera --> cannot go through objects with collider
    - FreeLook Camera (3rd Person - keeps player in focus)
    - Virtual Camera (1st Person Camera)
    - move with mouse or mouse pad
    - Player can switch between 1st and 3rd Person camera

In the Game

    - Scene Changer
        - text when changing scenes
        - only possible to change mountain levels/scenes when you achieved the requirements
        - cross fade to black when scene changes
    - Instruction texts that explain what to do
    - Beginning intructions when entering the game
    - text when you pick up items

Assets: imported and own
    
    - own created 
        - background landscape with unity terrain
        - mountain
        - platforms
        - stone
        - inventory
            - sprites of items
            - inventory panel
            - slot image
        - GUI skins for hovering text
        
    - imported
        - text mesh pro (automatically downloaded)
        - player (fox including animations)
        - environment
        - trees
        - items (excluded stones)
        - colour materials for mountain and grass (brown/green)
        - fire in level 5
        - sky box (changes during game progression --> 5 in total)
        - main menu background
        - ground texture for terrain
    
Game End

    - (main menu) end scene
    - "BackToLastScene" Button --> brings you back into the game to the end
    - "MainMenu" Button --> back to main menu/beginning
    - "QuitButton" --> quits/ends game 


## Issues We Faced
    - Warning message pops up about HDRP configuration 
        - happened only recently - we were a bit scared to fix it, we didn't know if it would negatively impact our completed, working game 
        
    - double jump (harder than expected)
        - we had a similar approach like normal jump with timer but did not work 
        - Solution: OnCollitionEnter to tag ground as ground and adding a jumpsremaining variable (--> see commented code player.cs)

    - asset import of fox
        - all animations playing in loop and player rising to sky
        - fixed by giving player a mesh filter and box collider specifically for falling through plane
        - additional rb fix rotation to make the player not fall to the sides
        - necessary to learn about animations

    - camera problems
        - following player was really unnatural (playr movement did not adapt to camera movement --> inverted movement control)
        - Solution: Add that input for player adapts to camera rotation excluding y rotation

    - inventroy
        - in general very hard and time consuming
        - several failed attempts
        - Solution: Trial and Error and a lot of internet research
        - hardest: adding functionality (being able to add and move items --> "script interact with UI")

    - created assets
        - figuring out blender 
        - importing assets correctly into unity (especially with bigger assets)
    
    - animator
        - rotating through idle animations
        - partially fixed by blend tree and randomized variable
        - blend tree added to first idle animation
        - still not working: fox sits down immediately and not after some time 

    - sound
        - initially easy
        - to have item pick up sound more difficulty
        - fixed with audio manager
        - figuring out that you cannot have multiple audio listeners (initially led to problems with scene changing and main menu)
    
    - Using keyboard input outside of Update() function
        - with OnTriggerStay(Collider other) so that keys get recognized
        - Picking up Items with E and when triggering Scene Change with 'ENTER' from L5 to End
        
    Scene Changer
        - Only triggering scene changer when certain objects are in inventory
            - Solution: Write function findItemInInventory and if statement in scene changer script
    
        - lighting bug at scene changer -> Shadows black when changing scene while playing
            - Solution: In 'Lighting', in 'workflow settings', click on 'Generate Lighting' while in each Scene (while not playing mode)
