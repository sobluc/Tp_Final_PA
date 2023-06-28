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

        // Recursive function to handle the y loop
        let rec printY x y =
            if y <= maxY then
                match Map.tryFind (x, y) coordsToSymbol with
                | Some symbol -> Console.Write(symbol)
                | None -> Console.Write(SBMap.outsideSymbol) // Default to outside if no block present at the coordinate
                printY x (y + 1)

        // Recursive function to handle the x loop
        let rec printX x =
            if x <= maxX then
                printY x 0
                Console.WriteLine()
                printX (x + 1)

        // Start printing the map
        Console.WriteLine($"Moves: {playerMoves}")
        printX 0


// keeps track of the game loop, printing the map updating map and ending game
module gameLoop = 
    // checks if the game is won by checking if there are any boxes left
    let gameIsWin (map : Block list) =
        let boxes = map |> List.filter (fun x -> match x with | Box _ -> true | _ -> false) |> List.length
        boxes = 0 // return true if there are no boxes left

    let rec mainLoop (map : Block list) (playerMoves) =
        let key = Console.ReadKey().KeyChar
        let rec reaskKey () :char =
            printfn "\bInvalid key, please try again. The valid keys are w, a, s, d to move, q to quit, and r to restart"
            let newkey = Console.ReadKey().KeyChar
            match newkey with
                | 'w' | 'a' | 's' | 'd' | 'q' | 'r' -> newkey
                | _ -> reaskKey()
        let newMovement = match key with
                            | 'w' | 'a' | 's' | 'd' | 'q' | 'r' -> user.castDirection key
                            | _ -> user.castDirection (reaskKey())
        if newMovement = user.Stop then
            printfn "\bGame stopped"
            //false
        else if newMovement = user.Restart then
            printfn "\bGame restarted"
            //true
        else
            let newMap, newPlayerMoves = user.move map newMovement playerMoves
            Console.Clear()
            GamePrint.PrintMap newMap newPlayerMoves        
            if gameIsWin newMap then
                printfn "Congratulations, you have won the game!"
                //false
            // if game isn't won then go back to loop with new map and new player moves
            else
                // GamePrint.deleteCurrentPrint newMap
                mainLoop newMap newPlayerMoves