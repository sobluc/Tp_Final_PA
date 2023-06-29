module userSBTests

open NUnit.Framework
open SokobanMapGenerator
open SokobanUserDynamics

[<SetUp>]
let Setup () =
    ()

[<Test>]
let MovingTest1 ()=
    // Checking the condition to move
    let result = user.isMovable (Floor (2,3)) (Floor (2,4))
    let expectation = true
    Assert.AreEqual(expectation, result)

[<Test>]
let MovingTest2 ()=
    // Checking the condition to move
    let result = user.isMovable (Floor (2,3)) (Wall (2,4))
    let expectation = true
    Assert.AreEqual(expectation, result)

[<Test>]
let MovingTest3 ()=
    // Checking the condition to move
    let result = user.isMovable (Floor (2,3)) (Box (2,4))
    let expectation = true
    Assert.AreEqual(expectation, result)


[<Test>]
let MovingTest4 ()=
    // Checking the condition to move
    let result = user.isMovable (Floor (2,3)) (Goal (2,4))
    let expectation = true
    Assert.AreEqual(expectation, result)


[<Test>]
let MovingTest5 ()=
    // Checking the condition to move
    let result = user.isMovable (Floor (2,3)) (BoxOnGoal (2,4))
    let expectation = true
    Assert.AreEqual(expectation, result)


[<Test>]
let MovingTest6 ()=
    // Checking the condition to move
    let result = user.isMovable (Box (2,3)) (Floor (2,4))
    let expectation = true
    Assert.AreEqual(expectation, result)


[<Test>]
let MovingTest7 ()=
    // Checking the condition to move
    let result = user.isMovable (Box (2,3)) (Goal (2,4))
    let expectation = true
    Assert.AreEqual(expectation, result)


[<Test>]
let MovingTest8 ()=
    // Checking the condition to move
    let result = user.isMovable (Box (2,3)) (Wall (2,4))
    let expectation = false
    Assert.AreEqual(expectation, result)


[<Test>]
let MovingTest9 ()=
    // Checking the condition to move
    let result = user.isMovable (Box (2,3)) (Box (2,4))
    let expectation = false
    Assert.AreEqual(expectation, result)

[<Test>]
let MovingTest10 ()=
    // Checking the condition to move
    let result = user.isMovable (Goal (2,3)) (Floor (2,4))
    let expectation = true
    Assert.AreEqual(expectation, result)

[<Test>]
let MovingTest11 ()=
    // Checking the condition to move
    let result = user.isMovable (Goal (2,3)) (Wall (2,4))
    let expectation = true
    Assert.AreEqual(expectation, result)

[<Test>]
let MovingTest12 ()=
    // Checking the condition to move
    let result = user.isMovable (Goal (2,3)) (Box (2,4))
    let expectation = true
    Assert.AreEqual(expectation, result)


[<Test>]
let MovingTest13 ()=
    // Checking the condition to move
    let result = user.isMovable (Goal (2,3)) (Goal (2,4))
    let expectation = true
    Assert.AreEqual(expectation, result)


[<Test>]
let MovingTest14 ()=
    // Checking the condition to move
    let result = user.isMovable (Goal (2,3)) (BoxOnGoal (2,4))
    let expectation = true
    Assert.AreEqual(expectation, result)


[<Test>]
let MovingTest15 ()=
    // Checking the condition to move
    let result = user.isMovable (Wall (2,3)) (Floor (2,4))
    let expectation = false
    Assert.AreEqual(expectation, result)

[<Test>]
let MovingTest16 ()=
    // Checking the condition to move
    let result = user.isMovable (Wall (2,3)) (Wall (2,4))
    let expectation = false
    Assert.AreEqual(expectation, result)

[<Test>]
let MovingTest17 ()=
    // Checking the condition to move
    let result = user.isMovable (Wall (2,3)) (Box (2,4))
    let expectation = false
    Assert.AreEqual(expectation, result)


[<Test>]
let MovingTest18 ()=
    // Checking the condition to move
    let result = user.isMovable (Wall (2,3)) (Goal (2,4))
    let expectation = false
    Assert.AreEqual(expectation, result)


[<Test>]
let MovingTest19 ()=
    // Checking the condition to move
    let result = user.isMovable (Wall (2,3)) (BoxOnGoal (2,4))
    let expectation = false
    Assert.AreEqual(expectation, result)


[<Test>]
let MovingTest20 ()=
    // Checking the condition to move
    let result = user.isMovable (BoxOnGoal (2,3)) (BoxOnGoal (2,4))
    let expectation = false
    Assert.AreEqual(expectation, result)

[<Test>]
let NextBlockTest1 ()=
    // A simple map for testing some cases and how the player moves
    let map = 
        [
            Player (2,2)
            Floor (2,3)
            Box (3,2)
            Goal (1,2)
            Wall (2,1)
        ]
    let result = user.nextBlock map Up (2,2)
    let expectation = Goal (1,2)
    Assert.AreEqual(expectation, result)


[<Test>]
let NextBlockTest2 ()=
    // A simple map for testing some cases and how the player moves
    let map = 
        [
            Player (2,2)
            Floor (2,3)
            Box (3,2)
            Goal (1,2)
            Wall (2,1)
        ]
    let result = user.nextBlock map Right (2,2)
    let expectation = Floor (2,3)
    Assert.AreEqual(expectation, result)


[<Test>]
let NextBlockTest3 ()=
    // A simple map for testing some cases and how the player moves
    let map = 
        [
            Player (2,2)
            Floor (2,3)
            Box (3,2)
            Goal (1,2)
            Wall (2,1)
        ]
    let result = user.nextBlock map Down (2,2)
    let expectation = Box (3,2)
    Assert.AreEqual(expectation, result)


[<Test>]
let NextBlockTest4 ()=
    // A simple map for testing some cases and how the player moves
    let map = 
        [
            Player (2,2)
            Floor (2,3)
            Box (3,2)
            Goal (1,2)
            Wall (2,1)
        ]
    let result = user.nextBlock map Left (2,2)
    let expectation = Wall (2,1)
    Assert.AreEqual(expectation, result)