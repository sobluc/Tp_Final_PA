module mapSBTests

open NUnit.Framework
open SokobanMapGenerator


[<SetUp>]
let Setup () =
    ()

[<Test>]
let castCharTest1 () =
    let coord = (0,0)
    let char = SBMap.wallSymbol

    Assert.AreEqual (Wall (0,0), SBMap.castChar char coord)

[<Test>]
let castCharTest2 () =
    let coord = (0,0)
    let char = SBMap.floorSymbol

    Assert.AreEqual (Floor (0,0), SBMap.castChar char coord)

[<Test>]
let castCharTest3 () =
    let coord = (0,0)
    let char = SBMap.playerOnGoalSymbol

    Assert.AreEqual (PlayerOnGoal (0,0), SBMap.castChar char coord)

[<Test>]
let castCharTest4 () =
    let coord = (0,0)
    let char = SBMap.playerSymbol

    Assert.AreEqual (Player (0,0), SBMap.castChar char coord)

[<Test>]
let castCharTest5 () =
    let coord = (0,0)
    let char = SBMap.boxSymbol

    Assert.AreEqual (Box (0,0), SBMap.castChar char coord)

[<Test>]
let castCharTest6 () =
    let coord = (0,0)
    let char = SBMap.boxOnGoalSymbol

    Assert.AreEqual (BoxOnGoal (0,0), SBMap.castChar char coord)

[<Test>]
let castCharTest7 () =
    let coord = (0,0)
    let char = SBMap.outsideSymbol

    Assert.AreEqual (Outside (0,0), SBMap.castChar char coord)

[<Test>]
let castCharTest8 () =
    let coord = (0,0)
    let char = SBMap.goalSymbol

    Assert.AreEqual (Goal (0,0), SBMap.castChar char coord)


[<Test>]
let getBlockListTest1 () =
    let testMap =  ["-|"; "> "; "#o"; "x^"]

    let maxLength = testMap |> Seq.map (fun x -> x.Length) |> Seq.max
    let seqLength = testMap.Length

    let map = SBMap.getBlockList maxLength seqLength testMap
    
    let expected = [    Outside (0,0); Wall (0,1); 
                                    Player (1,0) ; Floor (1,1); 
                                    Box (2,0); Goal (2,1);
                                    BoxOnGoal (3,0); PlayerOnGoal (3,1)
                                ]

    Assert.AreEqual (map,expected)

[<Test>]
let getBlockListTest2 () =
    let testMap =  ["-|##oo"; "> "; "#o"; "x^"]

    let maxLength = testMap |> Seq.map (fun x -> x.Length) |> Seq.max
    let seqLength = testMap.Length

    let map = SBMap.getBlockList maxLength seqLength testMap
    
    let expected = [    Outside (0,0); Wall (0,1); Box (0,2); Box (0,3); Goal (0,4); Goal (0,5); 
                                    Player (1,0) ; Floor (1,1); Outside (1,2); Outside (1,3); Outside (1,4); Outside (1,5);
                                    Box (2,0); Goal (2,1); Outside (2,2); Outside (2,3); Outside (2,4); Outside (2,5);
                                    BoxOnGoal (3,0); PlayerOnGoal (3,1); Outside (3,2); Outside (3,3); Outside (3,4); Outside (3,5)
                                ]

    Assert.AreEqual (map,expected)


[<Test>]
let notOnePlayerTest1 () =
    let testMap =  ["-|##oo"; "> "; "#o"; "x^"]

    let maxLength = testMap |> Seq.map (fun x -> x.Length) |> Seq.max
    let seqLength = testMap.Length

    let map = SBMap.getBlockList maxLength seqLength testMap
        

    Assert.AreEqual (map |> SBMap.notOnePlayer , true)

[<Test>]
let notOnePlayerTest2 () =
    let testMap =  ["-|oo"; "> "; "#o"; "x "]

    let maxLength = testMap |> Seq.map (fun x -> x.Length) |> Seq.max
    let seqLength = testMap.Length

    let map = SBMap.getBlockList maxLength seqLength testMap
        

    Assert.AreEqual (map |> SBMap.notOnePlayer , false)

[<Test>]
let notOnePlayerTest3 () =
    let testMap =  ["-|oo"; "^ "; "#o"; "x "]

    let maxLength = testMap |> Seq.map (fun x -> x.Length) |> Seq.max
    let seqLength = testMap.Length

    let map = SBMap.getBlockList maxLength seqLength testMap
        

    Assert.AreEqual (map |> SBMap.notOnePlayer , false)

[<Test>]
let notOnePlayerTest4 () =
    let testMap =  ["-|oo"; "^^^"; "#o"; "x "]

    let maxLength = testMap |> Seq.map (fun x -> x.Length) |> Seq.max
    let seqLength = testMap.Length

    let map = SBMap.getBlockList maxLength seqLength testMap
        

    Assert.AreEqual (map |> SBMap.notOnePlayer , true)



[<Test>]
let hasDifferentBoxAndGoalsTest1 () =
    let testMap =  ["-|oo"; "> "; "#o"; "x "]

    let maxLength = testMap |> Seq.map (fun x -> x.Length) |> Seq.max
    let seqLength = testMap.Length

    let map = SBMap.getBlockList maxLength seqLength testMap
        

    Assert.AreEqual (map |> SBMap.hasDifferentBoxAndGoals , true)


[<Test>]
let hasDifferentBoxAndGoalsTest2 () =
    let testMap =  ["-|o#"; "> "; "#o"; "x "]

    let maxLength = testMap |> Seq.map (fun x -> x.Length) |> Seq.max
    let seqLength = testMap.Length

    let map = SBMap.getBlockList maxLength seqLength testMap
        

    Assert.AreEqual (map |> SBMap.hasDifferentBoxAndGoals , false)


[<Test>]
let hasDifferentBoxAndGoalsTest3 () =
    let testMap =  ["-|xx"; "> "; "xx"; "x "]

    let maxLength = testMap |> Seq.map (fun x -> x.Length) |> Seq.max
    let seqLength = testMap.Length

    let map = SBMap.getBlockList maxLength seqLength testMap
        

    Assert.AreEqual (map |> SBMap.hasDifferentBoxAndGoals , false)

[<Test>]
let fillStringTest1 () =
    let testString =  "##oo"
    let fillNum = 3

    let filledString = SBMap.fillString testString fillNum
    let expected = "##oo---"
        

    Assert.AreEqual (filledString, expected)

[<Test>]
let fillStringTest2 () =
    let testString =  "##oo"
    let fillNum = 0

    let filledString = SBMap.fillString testString fillNum
    let expected = "##oo"
        

    Assert.AreEqual (filledString, expected)


[<Test>]
let fillStringTest3 () =
    let testString =  "##oo  "
    let fillNum = 5

    let filledString = SBMap.fillString testString fillNum
    let expected = "##oo  -----"
        

    Assert.AreEqual (filledString, expected)


[<Test>]
let castBlock1 () =
    let block = Wall (0,0)
    let char = SBMap.wallSymbol

    Assert.AreEqual (char, SBMap.castBlock block)

[<Test>]
let castBlock2 () =
    let block = Floor (0,0)
    let char = SBMap.floorSymbol

    Assert.AreEqual (char, SBMap.castBlock block)

[<Test>]
let castBlock3 () =
    let block = PlayerOnGoal (0,0)
    let char = SBMap.playerOnGoalSymbol

    Assert.AreEqual (char, SBMap.castBlock block)

[<Test>]
let castBlock4 () =
    let block = Player (0,0)
    let char = SBMap.playerSymbol

    Assert.AreEqual (char, SBMap.castBlock block)

[<Test>]
let castBlock5 () =
    let block = Box (0,0)
    let char = SBMap.boxSymbol

    Assert.AreEqual (char, SBMap.castBlock block)

[<Test>]
let castBlock6 () =
    let block = BoxOnGoal (0,0)
    let char = SBMap.boxOnGoalSymbol

    Assert.AreEqual (char, SBMap.castBlock block)

[<Test>]
let castBlock7 () =
    let block = Outside (0,0)
    let char = SBMap.floorSymbol

    Assert.AreEqual (char, SBMap.castBlock block)

[<Test>]
let castBlock8 () =
    let block = Goal (0,0)
    let char = SBMap.goalSymbol

    Assert.AreEqual (char, SBMap.castBlock block)


[<Test>]
let castToTuple1 () =
    let block = Wall (0,0)
    let tuple = (0,0)

    Assert.AreEqual (tuple, SBMap.castToTuple block)

[<Test>]
let castToTuple2 () =
    let block = Floor (0,0)
    let tuple = (0,0)

    Assert.AreEqual (tuple, SBMap.castToTuple block)

[<Test>]
let castToTuple3 () =
    let block = PlayerOnGoal (0,0)
    let tuple = (0,0)

    Assert.AreEqual (tuple, SBMap.castToTuple block)

[<Test>]
let castToTuple4 () =
    let block = Player (0,0)
    let tuple = (0,0)

    Assert.AreEqual (tuple, SBMap.castToTuple block)

[<Test>]
let castToTuple5 () =
    let block = Box (0,0)
    let tuple = (0,0)

    Assert.AreEqual (tuple, SBMap.castToTuple block)

[<Test>]
let castToTuple6 () =
    let block = BoxOnGoal (0,0)
    let tuple = (0,0)

    Assert.AreEqual (tuple, SBMap.castToTuple block)

[<Test>]
let castToTuple7 () =
    let block = Outside (0,0)
    let tuple = (0,0)

    Assert.AreEqual (tuple, SBMap.castToTuple block)

[<Test>]
let castToTuple8 () =
    let block = Goal (0,0)
    let tuple = (0,0)

    Assert.AreEqual (tuple, SBMap.castToTuple block)
