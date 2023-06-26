// Sokoban main program

open System
open SokobanMapGenerator


[<EntryPoint>]
printfn "Welcome to Sokoban!"
printfn "Please enter your username: "
let userInput = Console.ReadLine()

if userInput = "a" then
    printfn $"Hello {userInput}!"
else
    printfn $"Hello!"


let map = SBMap.readFromFile "levels/lvl1(34).txt"
printfn $"The map is: {map}"
