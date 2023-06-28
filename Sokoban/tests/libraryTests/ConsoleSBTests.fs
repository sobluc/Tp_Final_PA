module gameWinTest

open NUnit.Framework
open SokobanConsoleOutput
open SokobanMapGenerator

[<SetUp>]
let Setup () =
    ()


[<Test>]
let GetLevelWinTest1 ()=
    //define maps for testing where all boxes in the right place, map is list of type block from sokobanMapGenerator
        let map = 
        [
            Wall (0,0)
            Floor (1,1)
            Box (2,2)
            BoxOnGoal (3,3)
            Goal (4,4)
            Player (5,5)
            PlayerOnGoal (6,6)
            Outside (7,7)
        ]
        let result = gameLoop.gameIsWin map
        let expectation = false
        Assert.AreEqual(expectation, result)