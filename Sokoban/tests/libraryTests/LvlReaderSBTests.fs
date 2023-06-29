module lvlReaderTests

open NUnit.Framework
open SokobanLevelReader
open SokobanMapGenerator
[<SetUp>]
let Setup () =
    ()

[<Test>]
let GetLevelTest1 () =
    let userEntry = "1"
    let lvl = Lvl.getLvl userEntry
    Assert.AreEqual (One "levels/lvl1(34).txt",lvl)

[<Test>]
let GetLevelTest2 () =
    let userEntry = "2"
    let lvl = Lvl.getLvl userEntry
    Assert.AreEqual (Two "levels/lvl2(41).txt",lvl)

[<Test>]
let GetLevelTest3 () =
    let userEntry = "3"
    let lvl = Lvl.getLvl userEntry
    Assert.AreEqual (Three "levels/lvl3(102).txt",lvl)

[<Test>]
let GetLevelTest4 () =
    let userEntry = "4"
    let lvl = Lvl.getLvl userEntry
    Assert.AreEqual (Four "levels/lvl4(173).txt",lvl)

[<Test>]
let GetLevelTest5 () =
    let userEntry = "5"
    let lvl = Lvl.getLvl userEntry
    Assert.AreEqual (Five "levels/lvl5(204).txt",lvl)

[<Test>]
let GetLevelTest6 () =
    let userEntry = "6"
    let lvl = Lvl.getLvl userEntry
    Assert.AreEqual (Six "levels/lvl6(64).txt",lvl)

[<Test>]
let GetLevelTest7 () =
    let userEntry = "7"
    let lvl = Lvl.getLvl userEntry
    Assert.AreEqual (Seven "levels/lvl7(213).txt",lvl)

[<Test>]
let GetLevelTest8 () =
    let userEntry = "8"
    let lvl = Lvl.getLvl userEntry
    Assert.AreEqual (Eight "levels/lvl8(22).txt",lvl)

[<Test>]
let GetLevelTest9 () =
    let userEntry = "9"
    let lvl = Lvl.getLvl userEntry
    Assert.AreEqual (Nine "levels/lvl9(65).txt",lvl)

[<Test>]
let GetLevelTest10 () =
    let userEntry = "10"
    let lvl = Lvl.getLvl userEntry
    Assert.AreEqual (Ten "levels/lvl10(44).txt",lvl)

[<Test>]
let GetLevelTest11 () =
    let userEntry = "Tuto"
    let lvl = Lvl.getLvl userEntry
    Assert.AreEqual (Tutorial "levels/Tutorial.txt",lvl)

[<Test>]
let ReadLevelTest1 () =
    let userEntry = "1"
    let lvl = Lvl.getLvl userEntry
    let lvlpath = match lvl with
                    | One path -> "../../../../../src/main/"+path
                    | _ -> failwith "Wrong level"
        //"../../../../../src/main/levels/lvl1(34).txt"
    let map = Lvl.readLvl (One lvlpath)
    let boxCount = map 
                |> List.filter (fun x -> match x with
                                            | Box (c,d) -> true
                                            | BoxOnGoal (c,d) -> true
                                            | _ -> false)
                                            |> List.length
    let goalCount = map 
                    |> List.filter (fun x -> match x with
                                                | Goal (c,d) -> true
                                                | _ -> false)
                                                |> List.length
    let playerCount = map 
                    |> List.filter (fun x -> match x with
                                                | Player (c,d) -> true
                                                | PlayerOnGoal (c,d) -> true
                                                | _ -> false)
                                                |> List.length
    Assert.AreEqual (3,boxCount)
    Assert.AreEqual (3,goalCount)
    Assert.AreEqual (1,playerCount)
    Assert.AreEqual (156,map.Length)

[<Test>]
let ReadLevelTest2 () =
    let userEntry = "2"
    let lvl = Lvl.getLvl userEntry
    let lvlpath = match lvl with
                    | Two path -> "../../../../../src/main/"+path
                    | _ -> failwith "Wrong level"
        //"../../../../../src/main/levels/lvl1(34).txt"
    let map = Lvl.readLvl (Two lvlpath)
    let boxCount = map 
                |> List.filter (fun x -> match x with
                                            | Box (c,d) -> true
                                            | BoxOnGoal (c,d) -> true
                                            | _ -> false)
                                            |> List.length
    let goalCount = map 
                    |> List.filter (fun x -> match x with
                                                | Goal (c,d) -> true
                                                | BoxOnGoal (c,d) -> true
                                                | PlayerOnGoal (c,d) -> true
                                                | _ -> false)
                                                |> List.length
    let playerCount = map 
                    |> List.filter (fun x -> match x with
                                                | Player (c,d) -> true
                                                | PlayerOnGoal (c,d) -> true
                                                | _ -> false)
                                                |> List.length
    Assert.AreEqual (4,boxCount)
    Assert.AreEqual (4,goalCount)
    Assert.AreEqual (1,playerCount)
    Assert.AreEqual (156,map.Length)

[<Test>]
let ReadLevelTest3 () =
    let userEntry = "3"
    let lvl = Lvl.getLvl userEntry
    let lvlpath = match lvl with
                    | Three path -> "../../../../../src/main/"+path
                    | _ -> failwith "Wrong level"
        //"../../../../../src/main/levels/lvl1(34).txt"
    let map = Lvl.readLvl (Three lvlpath)
    let boxCount = map 
                |> List.filter (fun x -> match x with
                                            | Box (c,d) -> true
                                            | BoxOnGoal (c,d) -> true
                                            | _ -> false)
                                            |> List.length
    let goalCount = map 
                    |> List.filter (fun x -> match x with
                                                | Goal (c,d) -> true
                                                | BoxOnGoal (c,d) -> true
                                                | PlayerOnGoal (c,d) -> true
                                                | _ -> false)
                                                |> List.length
    let playerCount = map 
                    |> List.filter (fun x -> match x with
                                                | Player (c,d) -> true
                                                | PlayerOnGoal (c,d) -> true
                                                | _ -> false)
                                                |> List.length
    Assert.AreEqual (4,boxCount)
    Assert.AreEqual (4,goalCount)
    Assert.AreEqual (1,playerCount)
    Assert.AreEqual (121,map.Length)

[<Test>]
let ReadLevelTest4 () =
    let userEntry = "4"
    let lvl = Lvl.getLvl userEntry
    let lvlpath = match lvl with
                    | Four path -> "../../../../../src/main/"+path
                    | _ -> failwith "Wrong level"
        //"../../../../../src/main/levels/lvl1(34).txt"
    let map = Lvl.readLvl (Four lvlpath)
    let boxCount = map 
                |> List.filter (fun x -> match x with
                                            | Box (c,d) -> true
                                            | BoxOnGoal (c,d) -> true
                                            | _ -> false)
                                            |> List.length
    let goalCount = map 
                    |> List.filter (fun x -> match x with
                                                | Goal (c,d) -> true
                                                | BoxOnGoal (c,d) -> true
                                                | PlayerOnGoal (c,d) -> true
                                                | _ -> false)
                                                |> List.length
    let playerCount = map 
                    |> List.filter (fun x -> match x with
                                                | Player (c,d) -> true
                                                | PlayerOnGoal (c,d) -> true
                                                | _ -> false)
                                                |> List.length
    Assert.AreEqual (7,boxCount)
    Assert.AreEqual (7,goalCount)
    Assert.AreEqual (1,playerCount)
    Assert.AreEqual (130,map.Length)

[<Test>]
let ReadLevelTest5 () =
    let userEntry = "5"
    let lvl = Lvl.getLvl userEntry
    let lvlpath = match lvl with
                    | Five path -> "../../../../../src/main/"+path
                    | _ -> failwith "Wrong level"
        //"../../../../../src/main/levels/lvl1(34).txt"
    let map = Lvl.readLvl (Five lvlpath)
    let boxCount = map 
                |> List.filter (fun x -> match x with
                                            | Box (c,d) -> true
                                            | BoxOnGoal (c,d) -> true
                                            | _ -> false)
                                            |> List.length
    let goalCount = map 
                    |> List.filter (fun x -> match x with
                                                | Goal (c,d) -> true
                                                | BoxOnGoal (c,d) -> true
                                                | PlayerOnGoal (c,d) -> true
                                                | _ -> false)
                                                |> List.length
    let playerCount = map 
                    |> List.filter (fun x -> match x with
                                                | Player (c,d) -> true
                                                | PlayerOnGoal (c,d) -> true
                                                | _ -> false)
                                                |> List.length
    Assert.AreEqual (6,boxCount)
    Assert.AreEqual (6,goalCount)
    Assert.AreEqual (1,playerCount)
    Assert.AreEqual (132,map.Length)

[<Test>]
let ReadLevelTest6 () =
    let userEntry = "6"
    let lvl = Lvl.getLvl userEntry
    let lvlpath = match lvl with
                    | Six path -> "../../../../../src/main/"+path
                    | _ -> failwith "Wrong level"
        //"../../../../../src/main/levels/lvl1(34).txt"
    let map = Lvl.readLvl (Six lvlpath)
    let boxCount = map 
                |> List.filter (fun x -> match x with
                                            | Box (c,d) -> true
                                            | BoxOnGoal (c,d) -> true
                                            | _ -> false)
                                            |> List.length
    let goalCount = map 
                    |> List.filter (fun x -> match x with
                                                | Goal (c,d) -> true
                                                | BoxOnGoal (c,d) -> true
                                                | PlayerOnGoal (c,d) -> true
                                                | _ -> false)
                                                |> List.length
    let playerCount = map 
                    |> List.filter (fun x -> match x with
                                                | Player (c,d) -> true
                                                | PlayerOnGoal (c,d) -> true
                                                | _ -> false)
                                                |> List.length
    Assert.AreEqual (3,boxCount)
    Assert.AreEqual (3,goalCount)
    Assert.AreEqual (1,playerCount)
    Assert.AreEqual (90,map.Length)

[<Test>]
let ReadLevelTest7 () =
    let userEntry = "7"
    let lvl = Lvl.getLvl userEntry
    let lvlpath = match lvl with
                    | Seven path -> "../../../../../src/main/"+path
                    | _ -> failwith "Wrong level"
        //"../../../../../src/main/levels/lvl1(34).txt"
    let map = Lvl.readLvl (Seven lvlpath)
    let boxCount = map 
                |> List.filter (fun x -> match x with
                                            | Box (c,d) -> true
                                            | BoxOnGoal (c,d) -> true
                                            | _ -> false)
                                            |> List.length
    let goalCount = map 
                    |> List.filter (fun x -> match x with
                                                | Goal (c,d) -> true
                                                | BoxOnGoal (c,d) -> true
                                                | PlayerOnGoal (c,d) -> true
                                                | _ -> false)
                                                |> List.length
    let playerCount = map 
                    |> List.filter (fun x -> match x with
                                                | Player (c,d) -> true
                                                | PlayerOnGoal (c,d) -> true
                                                | _ -> false)
                                                |> List.length
    Assert.AreEqual (9,boxCount)
    Assert.AreEqual (9,goalCount)
    Assert.AreEqual (1,playerCount)
    Assert.AreEqual (156,map.Length)
    
[<Test>]
let ReadLevelTest8 () =
    let userEntry = "8"
    let lvl = Lvl.getLvl userEntry
    let lvlpath = match lvl with
                    | Eight path -> "../../../../../src/main/"+path
                    | _ -> failwith "Wrong level"
        //"../../../../../src/main/levels/lvl1(34).txt"
    let map = Lvl.readLvl (Eight lvlpath)
    let boxCount = map 
                |> List.filter (fun x -> match x with
                                            | Box (c,d) -> true
                                            | BoxOnGoal (c,d) -> true
                                            | _ -> false)
                                            |> List.length
    let goalCount = map 
                    |> List.filter (fun x -> match x with
                                                | Goal (c,d) -> true
                                                | BoxOnGoal (c,d) -> true
                                                | PlayerOnGoal (c,d) -> true
                                                | _ -> false)
                                                |> List.length
    let playerCount = map 
                    |> List.filter (fun x -> match x with
                                                | Player (c,d) -> true
                                                | PlayerOnGoal (c,d) -> true
                                                | _ -> false)
                                                |> List.length
    Assert.AreEqual (4,boxCount)
    Assert.AreEqual (4,goalCount)
    Assert.AreEqual (1,playerCount)
    Assert.AreEqual (80,map.Length)
    
[<Test>]
let ReadLevelTest9 () =
    let userEntry = "9"
    let lvl = Lvl.getLvl userEntry
    let lvlpath = match lvl with
                    | Nine path -> "../../../../../src/main/"+path
                    | _ -> failwith "Wrong level"
        //"../../../../../src/main/levels/lvl1(34).txt"
    let map = Lvl.readLvl (Nine lvlpath)
    let boxCount = map 
                |> List.filter (fun x -> match x with
                                            | Box (c,d) -> true
                                            | BoxOnGoal (c,d) -> true
                                            | _ -> false)
                                            |> List.length
    let goalCount = map 
                    |> List.filter (fun x -> match x with
                                                | Goal (c,d) -> true
                                                | BoxOnGoal (c,d) -> true
                                                | PlayerOnGoal (c,d) -> true
                                                | _ -> false)
                                                |> List.length
    let playerCount = map 
                    |> List.filter (fun x -> match x with
                                                | Player (c,d) -> true
                                                | PlayerOnGoal (c,d) -> true
                                                | _ -> false)
                                                |> List.length
    Assert.AreEqual (7,boxCount)
    Assert.AreEqual (7,goalCount)
    Assert.AreEqual (1,playerCount)
    Assert.AreEqual (108,map.Length)

    
[<Test>]
let ReadLevelTest10 () =
    let userEntry = "10"
    let lvl = Lvl.getLvl userEntry
    let lvlpath = match lvl with
                    | Ten path -> "../../../../../src/main/"+path
                    | _ -> failwith "Wrong level"
        //"../../../../../src/main/levels/lvl1(34).txt"
    let map = Lvl.readLvl (Ten lvlpath)
    let boxCount = map 
                |> List.filter (fun x -> match x with
                                            | Box (c,d) -> true
                                            | BoxOnGoal (c,d) -> true
                                            | _ -> false)
                                            |> List.length
    let goalCount = map 
                    |> List.filter (fun x -> match x with
                                                | Goal (c,d) -> true
                                                | BoxOnGoal (c,d) -> true
                                                | PlayerOnGoal (c,d) -> true
                                                | _ -> false)
                                                |> List.length
    let playerCount = map 
                    |> List.filter (fun x -> match x with
                                                | Player (c,d) -> true
                                                | PlayerOnGoal (c,d) -> true
                                                | _ -> false)
                                                |> List.length
    Assert.AreEqual (5,boxCount)
    Assert.AreEqual (5,goalCount)
    Assert.AreEqual (1,playerCount)
    Assert.AreEqual (81,map.Length)


[<Test>]
let ReadLevelTest11 () =
    let userEntry = "Tuto"
    let lvl = Lvl.getLvl userEntry
    let lvlpath = match lvl with
                    | Tutorial path -> "../../../../../src/main/"+path
                    | _ -> failwith "Wrong level"
        //"../../../../../src/main/levels/lvl1(34).txt"
    let map = Lvl.readLvl (Tutorial lvlpath)
    let boxCount = map 
                |> List.filter (fun x -> match x with
                                            | Box (c,d) -> true
                                            | BoxOnGoal (c,d) -> true
                                            | _ -> false)
                                            |> List.length
    let goalCount = map 
                    |> List.filter (fun x -> match x with
                                                | Goal (c,d) -> true
                                                | BoxOnGoal (c,d) -> true
                                                | PlayerOnGoal (c,d) -> true
                                                | _ -> false)
                                                |> List.length
    let playerCount = map 
                    |> List.filter (fun x -> match x with
                                                | Player (c,d) -> true
                                                | PlayerOnGoal (c,d) -> true
                                                | _ -> false)
                                                |> List.length
    Assert.AreEqual (1,boxCount)
    Assert.AreEqual (1,goalCount)
    Assert.AreEqual (1,playerCount)
    Assert.AreEqual (280,map.Length)