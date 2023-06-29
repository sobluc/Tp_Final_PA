namespace SokobanMapGenerator

exception InvalidChar of string
exception NumberOfPlayers of string
exception IsOpen of string
exception DifferentBoxAndGoals of string


open System.IO


type Block = 
    | Wall of int*int
    | Floor of int*int
    | Box of int*int
    | BoxOnGoal of int*int
    | Goal of int*int
    | Player of int*int
    | PlayerOnGoal of int*int
    | Outside of int*int



module SBMap =
    let wallSymbol = '|' // defines symbol for wall 
    let floorSymbol = ' ' // defines symbol for floor
    let boxSymbol = '#' // defines symbol for box
    let boxOnGoalSymbol = 'x' // defines symbol for when box is on top of goal
    let goalSymbol = 'o' // defines symbol for goal
    let playerSymbol = '>' // defines symbol for player
    let playerOnGoalSymbol = '^' // defines symbol for when player is on top of goal
    let outsideSymbol = '-' // defines symbol for outside

    let possibleSymbolsString =  string wallSymbol +
                                        " \t '" + string floorSymbol +
                                        "' \t " + string boxSymbol +
                                        " \t " + string boxOnGoalSymbol +
                                        " \t " + string goalSymbol +
                                        " \t " + string playerSymbol +
                                        " \t " + string boxOnGoalSymbol +
                                        " \t " + string outsideSymbol

    // castChar casts a given char at specified coordinates into a Block
    let castChar (c : char) (coord : int*int) : Block = 
        match c with
        | a when a = wallSymbol -> Wall coord
        | a when a = goalSymbol -> Goal coord
        | a when a = boxSymbol -> Box coord
        | a when a = playerSymbol -> Player coord
        | a when a = playerOnGoalSymbol -> PlayerOnGoal coord
        | a when a = boxOnGoalSymbol -> BoxOnGoal coord
        | a when a = floorSymbol -> Floor coord
        | a when a = outsideSymbol -> Outside coord
        | _ -> raise (InvalidChar ("Error al leer casillero. El simbolo '" + string c + "' no significa nada. Los posibles simbolos son " + possibleSymbolsString))

    // castBlock casts a Block into a char
    let castBlock (b : Block) : char = 
        match b with
        | Wall _ -> wallSymbol
        | Goal _ -> goalSymbol
        | Box _ -> boxSymbol
        | Player _ -> playerSymbol
        | PlayerOnGoal _ -> playerOnGoalSymbol
        | BoxOnGoal _ -> boxOnGoalSymbol
        | Floor _ -> floorSymbol
        | Outside _ -> floorSymbol

    // castToTuple returns the coordinates of a Block as a tuple
    let castToTuple (b : Block) : int*int = 
        match b with
        | Wall (x,y) -> (x,y)
        | Goal (x,y) -> (x,y)
        | Box (x,y) -> (x,y)
        | Player (x,y) -> (x,y)
        | PlayerOnGoal (x,y) -> (x,y)
        | BoxOnGoal (x,y) -> (x,y)
        | Floor (x,y) -> (x,y)
        | Outside (x,y) -> (x,y)

    // fillString fills a string with n 'Outside' blocks at the end
    let fillString (s : string) (n : int) : string =        
        let rec fillStringAux (s : string) (num : int) =
            match num with
            | a when a <= 0 -> s
            | _ -> fillStringAux (s + string outsideSymbol) (num - 1)
        fillStringAux s n


    // getBlockList generates a list with the coordinates of each symbol in the map casted to Block
    let getBlockList (maxStringLength : int) (listOfStringsLength : int) (listOfStrings : string seq) : Block list =
        // make each string have de same length filling it with 'Outside' blocks at the end:
        let seqAux = listOfStrings |> Seq.map (fun x -> fillString x (maxStringLength - x.Length))

        let rec loop2 (s : string) (i : int) (j : int) = 
            match j with
            | a when a = maxStringLength -> []
            | _ -> (castChar (s.[j]) (i, j)) :: loop2 s i (j + 1)

        let rec loop1 (list : string list) (i : int) =
            match i with
            | a when a = listOfStringsLength -> []   
            | _ ->  let listOfBlocks = loop2 (list.[i]) i 0 
                    List.append listOfBlocks (loop1 list (i + 1)) 

        loop1 (seqAux |> Seq.toList) 0


    // notOnePlayer returns false if there is only one player in the map, true otherwise
    let notOnePlayer (map : Block list) : bool =
        (map |> List.filter (fun x -> match x with | Player _ -> true | PlayerOnGoal _ -> true | _ -> false) |> List.length ) <> 1

    // hasDifferentBoxAndGoals returns true if there is a different number of boxes and goals, false otherwise
    let hasDifferentBoxAndGoals (map : Block list) : bool =
        let boxes = map |> List.filter (fun x -> match x with | Box _ -> true | _ -> false) |> List.length
        let goals = map |> List.filter (fun x -> match x with | Goal _ -> true | _ -> false) |> List.length
        boxes <> goals


    // readFromFile reads a text file with the desired map and returns a list of Block
    let readFromFile (inputFile : string) : Block list =
        let lines = File.ReadAllLines(inputFile)        
        let maxLineLength = lines |> Seq.map (fun x -> x.Length) |> Seq.max
        let numberOfLines = lines.Length

        let map = lines
                                |> getBlockList maxLineLength numberOfLines

        match map with
            | a when a |> notOnePlayer -> raise (NumberOfPlayers "Error al leer mapa. El mapa tiene que tener un solo jugador.")
            | a when a |> hasDifferentBoxAndGoals -> raise (DifferentBoxAndGoals "Error al leer mapa. La cantidad de cajas y objetivos es distinta.")
            | _ -> map