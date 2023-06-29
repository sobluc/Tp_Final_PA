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

[<Test>]
let MovementTest1 ()=
    // A simple map for testing some cases and how the player moves
    let map = 
        [
            Player (3,3)
            Floor (3,4)
            Wall (3,5)
            Box (4,3)
            Goal (5,3)
            Goal (2,3)
            Box (1,3)
            Wall (3,2)
            Outside (3,1)
        ]
    let result, newmoves = user.move map Left 0
    let expectation =
        [
            Player (3,3)
            Floor (3,4)
            Wall (3,5)
            Box (4,3)
            Goal (5,3)
            Goal (2,3)
            Box (1,3)
            Wall (3,2)
            Outside (3,1)
        ]
    Assert.AreEqual(expectation, result)
    Assert.AreEqual(0, newmoves)


[<Test>]
let MovementTest2 ()=
    // A simple map for testing some cases and how the player moves
    let map = 
        [
            Player (3,3)
            Floor (3,4)
            Wall (3,5)
            Box (4,3)
            Goal (5,3)
            Goal (2,3)
            Box (1,3)
            Wall (3,2)
            Outside (3,1)
        ]
    let result, newmoves = user.move map Up 0
    let expectation =
        [
            Floor (3,3)
            Floor (3,4)
            Wall (3,5)
            Box (4,3)
            Goal (5,3)
            PlayerOnGoal (2,3)
            Box (1,3)
            Wall (3,2)
            Outside (3,1)
        ]
    Assert.AreEqual(expectation, result)
    Assert.AreEqual(1, newmoves)


[<Test>]
let MovementTest3 ()=
    // A simple map for testing some cases and how the player moves
    let map = 
        [
            Player (3,3)
            Floor (3,4)
            Wall (3,5)
            Box (4,3)
            Goal (5,3)
            Goal (2,3)
            Box (1,3)
            Wall (3,2)
            Outside (3,1)
        ]
    let result, newmoves = user.move map Right 0
    let expectation =
        [
            Floor (3,3)
            Player (3,4)
            Wall (3,5)
            Box (4,3)
            Goal (5,3)
            Goal (2,3)
            Box (1,3)
            Wall (3,2)
            Outside (3,1)
        ]
    Assert.AreEqual(expectation, result)
    Assert.AreEqual(1, newmoves)


[<Test>]
let MovementTest4 ()=
    // A simple map for testing some cases and how the player moves
    let map = 
        [
            Player (3,3)
            Floor (3,4)
            Wall (3,5)
            Box (4,3)
            Goal (5,3)
            Goal (2,3)
            Box (1,3)
            Wall (3,2)
            Outside (3,1)
        ]
    let result, newmoves = user.move map Down 0
    let expectation =
        [
            Floor (3,3)
            Floor (3,4)
            Wall (3,5)
            Player (4,3)
            BoxOnGoal (5,3)
            Goal (2,3)
            Box (1,3)
            Wall (3,2)
            Outside (3,1)
        ]
    Assert.AreEqual(expectation, result)
    Assert.AreEqual(1, newmoves)
    

[<Test>]
let MovementTest5 ()=
    // A simple map for testing some cases and how the player moves
    let map = 
        [
            Player (3,3)
            Floor (3,4)
            Wall (3,5)
            BoxOnGoal (4,3)
            Goal (5,3)
            Goal (2,3)
            Box (1,3)
            Wall (3,2)
            Outside (3,1)
        ]
    let result, newmoves = user.move map Down 0
    let expectation =
        [
            Floor (3,3)
            Floor (3,4)
            Wall (3,5)
            PlayerOnGoal (4,3)
            BoxOnGoal (5,3)
            Goal (2,3)
            Box (1,3)
            Wall (3,2)
            Outside (3,1)
        ]
    Assert.AreEqual(expectation, result)
    Assert.AreEqual(1, newmoves)


[<Test>]
let MovementTest6 ()=
    // A simple map for testing some cases and how the player moves
    let map = 
        [
            PlayerOnGoal (3,3)
            Floor (3,4)
            Wall (3,5)
            Box (4,3)
            Goal (5,3)
            Goal (2,3)
            Box (1,3)
            Wall (3,2)
            Outside (3,1)
        ]
    let result, newmoves = user.move map Right 0
    let expectation =
        [
            Goal (3,3)
            Player (3,4)
            Wall (3,5)
            Box (4,3)
            Goal (5,3)
            Goal (2,3)
            Box (1,3)
            Wall (3,2)
            Outside (3,1)
        ]
    Assert.AreEqual(expectation, result)
    Assert.AreEqual(1, newmoves)


[<Test>]
let MovementTest7 ()=
    // A simple map for testing some cases and how the player moves
    let map = 
        [
            PlayerOnGoal (3,3)
            Floor (3,4)
            Wall (3,5)
            Box (4,3)
            Box (5,3)
            Goal (2,3)
            Box (1,3)
            Wall (3,2)
            Outside (3,1)
        ]
    let result, newmoves = user.move map Down 0
    let expectation =
        [
            PlayerOnGoal (3,3)
            Floor (3,4)
            Wall (3,5)
            Box (4,3)
            Box (5,3)
            Goal (2,3)
            Box (1,3)
            Wall (3,2)
            Outside (3,1)
        ]
    Assert.AreEqual(expectation, result)
    Assert.AreEqual(0, newmoves)


[<Test>]
let MovementTest8 ()=
    // A simple map for testing some cases and how the player moves
    let map = 
        [
            PlayerOnGoal (3,3)
            Floor (3,4)
            Wall (3,5)
            BoxOnGoal (4,3)
            Box (5,3)
            Goal (2,3)
            Box (1,3)
            Wall (3,2)
            Outside (3,1)
        ]
    let result, newmoves = user.move map Down 0
    let expectation =
        [
            PlayerOnGoal (3,3)
            Floor (3,4)
            Wall (3,5)
            BoxOnGoal (4,3)
            Box (5,3)
            Goal (2,3)
            Box (1,3)
            Wall (3,2)
            Outside (3,1)
        ]
    Assert.AreEqual(expectation, result)
    Assert.AreEqual(0, newmoves)


[<Test>]
let MovementTest9 ()=
    // A simple map for testing some cases and how the player moves
    let map = 
        [
            PlayerOnGoal (3,3)
            Floor (3,4)
            Wall (3,5)
            BoxOnGoal (4,3)
            BoxOnGoal (5,3)
            Goal (2,3)
            Box (1,3)
            Wall (3,2)
            Outside (3,1)
        ]
    let result, newmoves = user.move map Down 0
    let expectation =
        [
            PlayerOnGoal (3,3)
            Floor (3,4)
            Wall (3,5)
            BoxOnGoal (4,3)
            BoxOnGoal (5,3)
            Goal (2,3)
            Box (1,3)
            Wall (3,2)
            Outside (3,1)
        ]
    Assert.AreEqual(expectation, result)
    Assert.AreEqual(0, newmoves)


[<Test>]
let MovementTest10 ()=
    // A simple map for testing some cases and how the player moves
    let map = 
        [
            PlayerOnGoal (3,3)
            Floor (3,4)
            Wall (3,5)
            Box (4,3)
            BoxOnGoal (5,3)
            Goal (2,3)
            Box (1,3)
            Wall (3,2)
            Outside (3,1)
        ]
    let result, newmoves = user.move map Down 0
    let expectation =
        [
            PlayerOnGoal (3,3)
            Floor (3,4)
            Wall (3,5)
            Box (4,3)
            BoxOnGoal (5,3)
            Goal (2,3)
            Box (1,3)
            Wall (3,2)
            Outside (3,1)
        ]
    Assert.AreEqual(expectation, result)
    Assert.AreEqual(0, newmoves)


[<Test>]
let MovementTest11 ()=
    // A simple map for testing some cases and how the player moves
    let map = 
        [
            PlayerOnGoal (3,3)
            Box (3,4)
            Wall (3,5)
            BoxOnGoal (4,3)
            BoxOnGoal (5,3)
            Goal (2,3)
            Box (1,3)
            Wall (3,2)
            Outside (3,1)
        ]
    let result, newmoves = user.move map Right 0
    let expectation =
        [
            PlayerOnGoal (3,3)
            Box (3,4)
            Wall (3,5)
            BoxOnGoal (4,3)
            BoxOnGoal (5,3)
            Goal (2,3)
            Box (1,3)
            Wall (3,2)
            Outside (3,1)
        ]
    Assert.AreEqual(expectation, result)
    Assert.AreEqual(0, newmoves)


[<Test>]
let MovementTest12 ()=
    // A simple map for testing some cases and how the player moves
    let map = 
        [
            PlayerOnGoal (3,3)
            Floor (3,4)
            Wall (3,5)
            BoxOnGoal (4,3)
            BoxOnGoal (5,3)
            Goal (2,3)
            Box (1,3)
            Wall (3,2)
            Outside (3,1)
        ]
    let result, newmoves = user.move map Up 0
    let expectation =
        [
            Goal (3,3)
            Floor (3,4)
            Wall (3,5)
            BoxOnGoal (4,3)
            BoxOnGoal (5,3)
            PlayerOnGoal (2,3)
            Box (1,3)
            Wall (3,2)
            Outside (3,1)
        ]
    Assert.AreEqual(expectation, result)
    Assert.AreEqual(1, newmoves)


[<Test>]
let MovementTest13 ()=
    // A simple map for testing some cases and how the player moves
    let map = 
        [
            PlayerOnGoal (3,3)
            Floor (3,4)
            Wall (3,5)
            BoxOnGoal (4,3)
            Wall (5,3)
            Goal (2,3)
            Box (1,3)
            Wall (3,2)
            Outside (3,1)
        ]
    let result, newmoves = user.move map Down 0
    let expectation =
        [
            PlayerOnGoal (3,3)
            Floor (3,4)
            Wall (3,5)
            BoxOnGoal (4,3)
            Wall (5,3)
            Goal (2,3)
            Box (1,3)
            Wall (3,2)
            Outside (3,1)
        ]
    Assert.AreEqual(expectation, result)
    Assert.AreEqual(0, newmoves)


[<Test>]
let MovementTest14 ()=
    // A simple map for testing some cases and how the player moves
    let map = 
        [
            PlayerOnGoal (3,3)
            Floor (3,4)
            Wall (3,5)
            BoxOnGoal (4,3)
            Floor (5,3)
            Goal (2,3)
            Box (1,3)
            Wall (3,2)
            Outside (3,1)
        ]
    let result, newmoves = user.move map Down 0
    let expectation =
        [
            Goal (3,3)
            Floor (3,4)
            Wall (3,5)
            PlayerOnGoal (4,3)
            Box (5,3)
            Goal (2,3)
            Box (1,3)
            Wall (3,2)
            Outside (3,1)
        ]
    Assert.AreEqual(expectation, result)
    Assert.AreEqual(1, newmoves)

[<Test>]
let MovementTest15 ()=
    // A test in case for some reason the direction is not Up, Down, Left or Right
    // This should throw an exception InvalidChar
    let map = 
        [
            PlayerOnGoal (3,3)
            Floor (3,4)
            Wall (3,5)
            BoxOnGoal (4,3)
            Floor (5,3)
            Goal (2,3)
            Box (1,3)
            Wall (3,2)
            Outside (3,1)
        ]
    let expectation =
        [
            Goal (3,3)
            Floor (3,4)
            Wall (3,5)
            PlayerOnGoal (4,3)
            Box (5,3)
            Goal (2,3)
            Box (1,3)
            Wall (3,2)
            Outside (3,1)
        ]
    try
        let result, newmoves = user.move map Invalid 0

        // Fail the test if the exception is not thrown
        Assert.Fail("Expected exception was not thrown")
    with
    | :? InvalidChar as ex ->
        // Assert the exception message
        Assert.AreEqual("InvalidChar\n  \"This function does not accept other directions than Up, Left, Down, and Right\"", ex.Message)
    | _ ->
        // Fail the test if an exception of a different type is thrown
        Assert.Fail("Unexpected exception was thrown")
    
