// Sokoban main program

open System

[<EntryPoint>]
printfn "Welcome to Sokoban!"
printfn "Please enter your username: "
let userInput = Console.ReadLine()

if userInput = "a" then
    printfn $"Hello {userInput}!"
else
    printfn $"Hello!"

