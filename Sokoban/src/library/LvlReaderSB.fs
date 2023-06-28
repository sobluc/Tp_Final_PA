namespace SokobanLevelReader

open SokobanMapGenerator

type Level =
    | Tutorial of string
    | One of string
    | Two of string
    | Three of string
    | Four of string
    | Five of string
    | Six of string
    | Seven of string
    | Eight of string
    | Nine of string
    | Ten of string
    
module Lvl =
    // getLvl translates the user's answer to a level type with the path to each level file.
    // The name of the level file has the minimum number of steps to complete the level between parentheses (...)
    let getLvl (userAnswer : string) : Level =
        match userAnswer with
        | "1" -> One "levels/lvl1(34).txt"
        | "2" -> Two "levels/lvl2(41).txt"
        | "3" -> Three "levels/lvl3(102).txt"
        | "4" -> Four "levels/lvl4(173).txt"
        | "5" -> Five "levels/lvl5(204).txt"
        | "6" -> Six "levels/lvl6(64).txt"
        | "7" -> Seven "levels/lvl7(213).txt"
        | "8" -> Eight "levels/lvl8(22).txt"
        | "9" -> Nine "levels/lvl9(65).txt"
        | "10" -> Ten "levels/lvl10(44).txt"
        | _ -> Tutorial "levels/Tutorial.txt"    
    
    // readLvl reads the level file and returns a list of blocks
    let readLvl (lvl : Level) : Block list = 
        match lvl with
        | Tutorial path -> SBMap.readFromFile path
        | One path -> SBMap.readFromFile path
        | Two path -> SBMap.readFromFile path
        | Three path -> SBMap.readFromFile path
        | Four path -> SBMap.readFromFile path
        | Five path -> SBMap.readFromFile path
        | Six path -> SBMap.readFromFile path
        | Seven path -> SBMap.readFromFile path
        | Eight path -> SBMap.readFromFile path
        | Nine path -> SBMap.readFromFile path
        | Ten path -> SBMap.readFromFile path
