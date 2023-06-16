namespace SokobanUserDynamics

open SokobanMapGenerator

module user =
    let getCoordinate (block : Block) =
        match block with
        | Wall (c, d) -> (c, d)
        | Box (c, d) -> (c, d)
        | BoxOnGoal (c, d) -> (c, d)
        | Player (c, d) -> (c, d)
        | PlayerOnGoal (c, d) -> (c, d)
        | Goal (c, d) -> (c, d)
        | Floor (c, d) -> (c, d)
        | Outside (c, d) -> (c, d)

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

    let nextBlock (map: Block list) (key: char) (coord:int*int) : Block =
        let nextCoord = match key with
                        | 'w' -> (fst coord-1, snd coord)
                        | 'a' -> (fst coord, snd coord-1)
                        | 's' -> (fst coord+1, snd coord)
                        | 'd' -> (fst coord, snd coord+1)
                        | _ -> raise (InvalidChar ("Error en el movimiendo. El simbolo '" + string key + "' no tiene ningun significado. Los posibles simbolos son w, a, s, d."))
        map
        |> List.find (fun x -> getCoordinate x = nextCoord)

    let move (oldmap:Block list) (key:char) :Block list =
        let player = oldmap
                            |>List.find(fun x -> match x with
                                                    | Player _ -> true
                                                    | PlayerOnGoal _ -> true
                                                    | _ -> false)
        let playerCoord = getCoordinate player
        let oneBlockAway = nextBlock oldmap key playerCoord
        let twoBlocksAway = nextBlock oldmap key (getCoordinate oneBlockAway)
        if isMovable oneBlockAway twoBlocksAway then
            oldmap
            |> List.map (fun x -> match x with
                                    | Player (c, d) -> Floor (c, d)
                                    | PlayerOnGoal (c, d) -> Goal (c, d)
                                    | _ when x = oneBlockAway -> match oneBlockAway with
                                                                    | Goal (c, d) -> PlayerOnGoal (c, d)
                                                                    | BoxOnGoal (c,d) -> PlayerOnGoal (c, d)
                                                                    | _ -> Player (getCoordinate oneBlockAway)
                                    | _ when x = twoBlocksAway -> match twoBlocksAway with
                                                                    | Goal (c,d) -> match oneBlockAway with
                                                                                        | Box (e,f) -> BoxOnGoal (getCoordinate twoBlocksAway)
                                                                                        | BoxOnGoal (e,f) -> BoxOnGoal (getCoordinate twoBlocksAway)
                                                                                        | _ -> Goal (getCoordinate twoBlocksAway)
                                                                    | _ -> match oneBlockAway with
                                                                                | Box (c,d) -> Box (getCoordinate twoBlocksAway)
                                                                                | BoxOnGoal (c,d) -> Box (getCoordinate twoBlocksAway)
                                                                                | _ -> twoBlocksAway
                                    | _ -> x)
        else
            oldmap

