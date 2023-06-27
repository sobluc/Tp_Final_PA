// Sokoban main program

open System
open SokobanMapGenerator
open SokobanLevelReader
open SokobanConsoleOutput
[<EntryPoint>]
printfn "Welcome to Sokoban!"
printfn "Please enter your username: "
let userInput = Console.ReadLine()

if userInput = "a" then
    printfn $"Hello {userInput}!"
else
    printfn $"Hello!"


let level = Lvl.getLvl "1"

printfn $"The map is: {Lvl.readLvl level}"
let number_moves = 0
GamePrint.PrintMap (Lvl.readLvl level ) number_moves 

gameLoop.loop (Lvl.readLvl level) number_moves