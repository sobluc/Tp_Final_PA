// Sokoban main program

open System
open SokobanLevelReader
open SokobanConsoleOutput
open SokobanUserDynamics

[<EntryPoint>]
Console.Clear()
printfn "Welcome to Sokoban!"
printfn "Please enter your username: "
let userName = Console.ReadLine()

Console.Clear()
printfn $"Hello {userName}!"
printfn "To play use W (up), A (left), S (down) and D (right) to move the player (>)."
printfn "You can also use R to restart the level, Q to quit the game, and C to change the level."
let rec levelLoop ()=
    printfn "Please enter the level you want to play (1-10 or anything different for tutorial): "
    let userAnswer = Console.ReadLine()
    let level = Lvl.getLvl userAnswer

    let rec restartLoop() =
        Console.Clear()
        let numberMoves = 0
        GamePrint.PrintMap (Lvl.readLvl level) numberMoves 

        let action = gameLoop.mainLoop (Lvl.readLvl level) numberMoves
        match action with
        | Stop ->    printfn "\bGame Over"
        | Restart -> restartLoop()
        | ChangeLevel ->    Console.Clear()
                            levelLoop()
        | _ ->       printfn "Error. Game Over"
    restartLoop()
levelLoop()
