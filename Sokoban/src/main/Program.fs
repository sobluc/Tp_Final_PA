// Sokoban main program

open System
open SokobanLevelReader
open SokobanConsoleOutput

[<EntryPoint>]
Console.Clear()
printfn "Welcome to Sokoban!"
printfn "Please enter your username: "
let userName = Console.ReadLine()

Console.Clear()
printfn $"Hello {userName}!"

printfn "To play use W (up), A (left), S (down) and D (right) to move the player (>)."
printfn "Please enter the level you want to play (1-10 or anything different for tutorial): "
let userAnswer = Console.ReadLine()
let level = Lvl.getLvl userAnswer

Console.Clear()
let numberMoves = 0
GamePrint.PrintMap (Lvl.readLvl level) numberMoves 

gameLoop.mainLoop (Lvl.readLvl level) numberMoves