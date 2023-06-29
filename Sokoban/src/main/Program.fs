﻿// Sokoban main program

open System
open SokobanLevelReader
open SokobanConsoleOutput
open SokobanUserDynamics

[<EntryPoint>]
Console.Clear()
printfn "Welcome to Sokoban!"
printfn "Please enter your username: "
let userName = Console.ReadLine()

// This part introduces the game and the rules to the user
Console.Clear()
printfn $"Hello {userName}!"
printfn "To play use W (up), A (left), S (down) and D (right) to move the player (>)."
printfn "You can also use R to restart the level, Q to quit the game, and C to change the level."
// Now we ask the user to choose a level
// It is a recursive function that will start again if the user chooses to change the level later
let rec levelLoop ()=
    printfn "Please enter the level you want to play (1-10 or anything different for tutorial): "
    let userAnswer = Console.ReadLine()
    let level = Lvl.getLvl userAnswer

    // This is the loop that will restart the game if the user chooses to restart, back to 0 movements
    let rec restartLoop() =
        Console.Clear()
        let numberMoves = 0
        GamePrint.PrintMap (Lvl.readLvl level) numberMoves 

        // This is the loop that will keep the game going until the user chooses to stop, restart or change level
        // The loop will also stop if the user wins the game, and either choose to change level or stop
        let action = gameLoop.mainLoop (Lvl.readLvl level) numberMoves
        match action with
        | Stop ->    printfn "\bGame Over"
        | Restart -> restartLoop()
        | ChangeLevel ->    Console.Clear()
                            levelLoop()
        | _ ->       printfn "Error. Game Over"
    restartLoop()
levelLoop()
