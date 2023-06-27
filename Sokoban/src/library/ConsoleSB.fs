namespace SokobanConsoleOutput

open SokobanLevelReader
open System
open SokobanUserDynamics
open SokobanMapGenerator



// prints map in console
module GamePrint =
    let PrintMap (map : Block list)  =
        let coordsToSymbol = 
            map 
            |> List.map (fun block -> SBMap.castToTuple block, SBMap.castBlock  block)
            |> Map.ofList

        let maxX = map |> List.maxBy (fun block -> fst (SBMap.castToTuple block)) |> SBMap.castToTuple |> fst
        let maxY = map |> List.maxBy (fun block -> snd (SBMap.castToTuple block)) |> SBMap.castToTuple |> snd

        for x in 0 .. maxX do
            for y in 0 .. maxY do
                match Map.tryFind (x, y) coordsToSymbol with
                | Some symbol -> Console.Write(symbol)
                | None -> Console.Write(SBMap.outsideSymbol) // Default to outside if no block present at the coordinate
            Console.WriteLine()



