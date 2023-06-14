namespace SokobanMapGenerator

exception InvalidChar of string


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
    let wallSymbol = '|'
    let floorSymbol = ' '
    let boxSymbol = '['
    let boxOnGoalSymbol = '('
    let goalSymbol = '.'
    let playerSymbol = '>'
    let playerOnGoalSymbol = '^'
    let outsideSymbol = '-'

    // castChar convierte un char a un Block
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
        | _ -> raise (InvalidChar ("Error al leer casillero. El simbolo '" + string c + "' no significa nada. Los posibles simbolos son {#, x, c, >, <, +, ' ', -}."))

    // castBlock convierte un Block a un char
    let castBlock (b : Block) : char = 
        match b with
        | Wall _ -> wallSymbol
        | Goal _ -> goalSymbol
        | Box _ -> boxSymbol
        | Player _ -> playerSymbol
        | PlayerOnGoal _ -> playerOnGoalSymbol
        | BoxOnGoal _ -> boxOnGoalSymbol
        | Floor _ -> floorSymbol
        | Outside _ -> outsideSymbol


    // fillString rellena un string con n bloques Outside al final
    let fillString (s : string) (n : int) : string =        
        let rec fillStringAux (s : string) (num : int) =
            match num with
            | a when a <= 0 -> s
            | _ -> fillStringAux (s + string outsideSymbol) (num - 1)
        fillStringAux s n

    // fillOutside rellena el borde del mapa con bloques Outside
    let replaceOutside (s : string) (n : int): string =        
        let filled = fillString s (n - s.Length) 
        let filledCharArray = filled.ToCharArray() |> Seq.toList

        let rec fillOutsideAux (charList : char list) =
            match charList with
            | [] -> []
            | _ ->     
                let h = charList.Head
                let t = charList.Tail
                match h with
                | a when a = wallSymbol -> charList
                | _ -> outsideSymbol::fillOutsideAux t

        let beginOutside = fillOutsideAux filledCharArray
        let endOutside = fillOutsideAux (beginOutside |> List.rev)

        endOutside |> List.rev |> List.toArray |> System.String




    // getBlockList genera una lista con las coordenadas de cada simbolo en el mapa casteadas a Block
    let getBlockList (maxStringLength : int) (listOfStringsLength : int) (listOfStrings : string seq) : Block list =
        let firstAndLastLine = replaceOutside "" maxStringLength

        let rec loop2 (s : string) (i : int) (j : int) = 
            match j with
            | a when a = maxStringLength -> []
            | _ -> (castChar (s.[j]) (i, j)) :: loop2 s i (j + 1)

        let rec loop1 (list : string list) (i : int) =
            match i with
            | a when a = listOfStringsLength + 2 -> []   // el 2 es porque añadi una fila al inicio y otra al final de la lista
            | _ ->  let listOfBlocks = loop2 (list.[i]) i 0 
                    List.append listOfBlocks (loop1 list (i + 1)) 

        let listWithFirst = firstAndLastLine::(listOfStrings |> Seq.toList)
        let listWithFirstAndLast = List.append listWithFirst [firstAndLastLine]
        
        loop1 listWithFirstAndLast 0


    // readFromFile crea una lista de Block a partir de un archivo de texto
    let readFromFile (inputFile : string) : Block list =
        let lines = File.ReadAllLines(inputFile)        
        let maxLineLength = lines |> Seq.map (fun x -> x.Length) |> Seq.max
        let numberOfLines = lines.Length

        lines
        |> Seq.map (fun x -> replaceOutside x maxLineLength)
        |> getBlockList maxLineLength numberOfLines