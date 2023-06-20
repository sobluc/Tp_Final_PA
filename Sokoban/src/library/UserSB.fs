namespace SokobanUserDynamics

open SokobanMapGenerator

module user =
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
    let nextBlock (map: Block list) (key: char) (coord:int*int) : Block =
        let nextCoord = match key with
                        | 'w' -> (fst coord-1, snd coord)
                        | 'a' -> (fst coord, snd coord-1)
                        | 's' -> (fst coord+1, snd coord)
                        | 'd' -> (fst coord, snd coord+1)
                        | _ -> raise (InvalidChar ("Error en el movimiendo. El simbolo '" + string key + "' no tiene ningun significado. Los posibles simbolos son w, a, s, d."))
        map
        |> List.find (fun x -> SBMap.castToTuple x = nextCoord)

    // move moves the player and the corresponding blocks, so it
    // returns a new map with the player and the blocks moved
    let move (oldmap:Block list) (key:char) :Block list =
        let player = oldmap
                            |>List.find(fun x -> match x with
                                                    | Player _ -> true
                                                    | PlayerOnGoal _ -> true
                                                    | _ -> false)
        let playerCoord = SBMap.castToTuple player
        let oneBlockAway = nextBlock oldmap key playerCoord
        let twoBlocksAway = nextBlock oldmap key (SBMap.castToTuple oneBlockAway)
        if isMovable oneBlockAway twoBlocksAway then
            oldmap
            |> List.map (fun x -> match x with
                                    | Player (c, d) -> Floor (c, d) // Player is moved to the next block, and the previous block is turned into a floor
                                    | PlayerOnGoal (c, d) -> Goal (c, d) // Player is moved to the next block, and the previous block is turned into a goal
                                    | _ when x = oneBlockAway -> match oneBlockAway with // The block one block away now has the player
                                                                    | Goal (c, d) -> PlayerOnGoal (c, d)
                                                                    | BoxOnGoal (c,d) -> PlayerOnGoal (c, d)
                                                                    | Outside (c,d) -> raise (IsOpen ("Error al mover el jugador. El jugador se ha salido del mapa."))
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
        else
            oldmap // If the block can't be moved, the map is left as it was

