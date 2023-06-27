module lvlReaderTests

open NUnit.Framework
open SokobanLevelReader

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