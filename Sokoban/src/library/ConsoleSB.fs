namespace SokobanConsoleOutput

open System
open SokobanUserDynamics
open SokobanMapGenerator



// prints map in console
module GamePrint =
    let PrintMap (map : Block list) (playerMoves)  =
        let coordsToSymbol = 
            map 
            |> List.map (fun block -> SBMap.castToTuple block, SBMap.castBlock  block)
            |> Map.ofList

        let maxX = map |> List.maxBy (fun block -> fst (SBMap.castToTuple block)) |> SBMap.castToTuple |> fst
        let maxY = map |> List.maxBy (fun block -> snd (SBMap.castToTuple block)) |> SBMap.castToTuple |> snd
        //add quantity of moves 
        Console.WriteLine($"Moves: {playerMoves}")
        for x in 0 .. maxX do
            for y in 0 .. maxY do
                match Map.tryFind (x, y) coordsToSymbol with
                | Some symbol -> Console.Write(symbol)
                | None -> Console.Write(SBMap.outsideSymbol) // Default to outside if no block present at the coordinate
            Console.WriteLine()


module gameLoop = 
    // checks if the game is won by checking if there are any boxes left
    let gameIsWin (map : Block list) =
        let boxes = map |> List.filter (fun x -> match x with | Box _ -> true | _ -> false) |> List.length
        boxes = 0 // return true if there are no boxes left

    let rec mainLoop (map : Block list) (playerMoves) =
        let newMovement = Console.ReadKey().KeyChar
        let newMap, newPlayerMoves = user.move map newMovement playerMoves
        Console.Clear()
        GamePrint.PrintMap newMap newPlayerMoves        
        if gameIsWin newMap then
            printfn "Congratulations, you have won the game!"
        // if game isn't won then go back to loop with new map and new player moves
        else
            // GamePrint.deleteCurrentPrint newMap
            mainLoop newMap newPlayerMoves