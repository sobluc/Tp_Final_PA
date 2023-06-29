namespace SokobanConsoleOutput

open System
open SokobanUserDynamics
open SokobanMapGenerator
open SokobanLevelReader

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

    // main loop of the game, takes in the map and the player moves
    let rec mainLoop (map : Block list) (playerMoves) =
        let key = Console.ReadKey().KeyChar
        let rec reaskKey () :intention =
            printfn "\bInvalid key, please try again. The valid keys are w, a, s, d to move, q to quit, r to restart and c to change level"
            let newkey = Console.ReadKey().KeyChar
            let newintention = user.castIntention newkey
            match newintention with
                | Invalid -> reaskKey() // If the new key is invalid, the function is called again, so the action never becomes Invalid
                | _ -> newintention
        let intention = user.castIntention key
        let action = match intention with
                                | Invalid -> reaskKey()
                                | _ -> intention
        match action with
        | Stop Exit | Restart | ChangeLevel -> action // In one of this cases, the current game ends and the program will handle it
        // The other cases are the movement cases, since Invalid is handled above, we can safely assume that the action is a movement
        | _ ->  let newMap, newPlayerMoves = user.move map action playerMoves
                Console.Clear() // The console is cleared to avoid printing the map multiple times
                GamePrint.PrintMap newMap newPlayerMoves // The map is printed 
                if gameIsWin newMap then
                    Stop (Win newPlayerMoves) // If the game is won, the game ends and the program will handle the rest
                else
                    mainLoop newMap newPlayerMoves // If the game is not won, the game continues