// Sokoban main program

open System
open SokobanMapGenerator
open SokobanLevelReader
open SokobanConsoleOutput

[<EntryPoint>]
printfn "Welcome to Sokoban!"
printfn "Please enter your username: "
let userInput = Console.ReadLine()


printfn $"Hello {userInput}!"


printfn "Please enter the level you want to play (1-10 or anything different for tutorial): "
let userAnswer = Console.ReadLine()
let level = Lvl.getLvl userAnswer

let number_moves = 0
GamePrint.PrintMap (Lvl.readLvl level ) number_moves 

gameLoop.loop (Lvl.readLvl level) number_moves