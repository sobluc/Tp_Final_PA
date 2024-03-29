namespace SokobanUserDynamics

open SokobanMapGenerator

type condition =
    | Win of int
    | Exit


type intention = 
    | Up
    | Down
    | Left
    | Right
    | Stop of condition
    | Restart
    | ChangeLevel
    | Invalid

module user =
    let castIntention (key:char) =
        match key with
        | 'w' -> Up
        | 'W' -> Up
        | 'a' -> Left
        | 'A' -> Left
        | 's' -> Down
        | 'S' -> Down
        | 'd' -> Right
        | 'D' -> Right
        | 'r' -> Restart
        | 'R' -> Restart
        | 'q' -> Stop Exit
        | 'Q' -> Stop Exit
        | 'c' -> ChangeLevel
        | 'C' -> ChangeLevel
        | _ -> Invalid
        
    // isMovable decides if a block is movable given the next block
    // e.g. if the next block is another box, it can't be moved
    let isMovable (oneBlockAway:Block) (twoBlocksAway:Block) :bool=
        match oneBlockAway with
        | Wall _ -> false
        | Box _ -> match twoBlocksAway with
                    | Wall _ -> false
                    | Box _ -> false
                    | BoxOnGoal _ -> false
                    | _ -> true
        | BoxOnGoal _ -> match twoBlocksAway with
                            | Wall _ -> false
                            | Box _ -> false
                            | BoxOnGoal _ -> false
                            | _ -> true
        | _ -> true

    // nextBlock returns the next block from coordinate coord, given the direction key and the map
    // It must be noted that the x index goes from top to bottom, and the y index goes from left to right
    let nextBlock (map: Block list) (direction: intention) (coord:int*int) : Block =
        let nextCoord = match direction with
                        | Up -> (fst coord-1, snd coord)
                        | Left -> (fst coord, snd coord-1)
                        | Down -> (fst coord+1, snd coord)
                        | Right -> (fst coord, snd coord+1)
                        | _ -> raise (InvalidChar ("This function does not accept other directions than Up, Left, Down, and Right"))
        map
        |> List.find (fun x -> SBMap.castToTuple x = nextCoord)

    // move moves the player and the corresponding blocks, so it
    // returns a new map with the player and the blocks moved
    let move (oldmap:Block list) (direction:intention) (moves:int) :Block list*int =
        let player = oldmap
                            |>List.find(fun x -> match x with
                                                    | Player _ -> true
                                                    | PlayerOnGoal _ -> true
                                                    | _ -> false)
        let playerCoord = SBMap.castToTuple player
        let oneBlockAway = nextBlock oldmap direction playerCoord
        let twoBlocksAway = nextBlock oldmap direction (SBMap.castToTuple oneBlockAway)
        if isMovable oneBlockAway twoBlocksAway then
            (List.map (fun x -> match x with
                                    | Player (c, d) -> Floor (c, d) // Player is moved to the next block, and the previous block is turned into a floor
                                    | PlayerOnGoal (c, d) -> Goal (c, d) // Player is moved to the next block, and the previous block is turned into a goal
                                    | _ when x = oneBlockAway -> match oneBlockAway with // The block one block away now has the player
                                                                    | Goal (c, d) -> PlayerOnGoal (c, d)
                                                                    | BoxOnGoal (c,d) -> PlayerOnGoal (c, d)
                                                                    | Outside (c,d) -> raise (IsOpen ("Movement error. The player is outside the map."))
                                                                    | _ -> Player (SBMap.castToTuple oneBlockAway)
                                    | _ when x = twoBlocksAway -> match twoBlocksAway with // The block one block away now is the block two blocks away (because it is mmoved)
                                                                    | Goal (c,d) -> match oneBlockAway with
                                                                                        | Box (e,f) -> BoxOnGoal (SBMap.castToTuple twoBlocksAway)
                                                                                        | BoxOnGoal (e,f) -> BoxOnGoal (SBMap.castToTuple twoBlocksAway)
                                                                                        | _ -> Goal (SBMap.castToTuple twoBlocksAway)
                                                                    | _ -> match oneBlockAway with
                                                                                | Box (c,d) -> Box (SBMap.castToTuple twoBlocksAway)
                                                                                | BoxOnGoal (c,d) -> Box (SBMap.castToTuple twoBlocksAway)
                                                                                | _ -> twoBlocksAway
                                    | _ -> x) // The rest of the blocks are left as they were
                                    oldmap, moves+1) // The number of moves is increased
        else
            (oldmap, moves) // If the block can't be moved, the map is left as it was, and the moves stay the same