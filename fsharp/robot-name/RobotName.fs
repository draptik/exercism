module RobotName

open System

let rand = new System.Random()

let generateRandomStringOf3Numbers (r : Random) =
    r.Next(1000) // min: 0, max: 999
    |> sprintf "%03i" // left pad with zeros

// https://stackoverflow.com/a/33316100/1062607
let shuffleR (r : Random) xs =
    xs
    |> Seq.sortBy (fun _ -> r.Next())

let generate2RandomUpperCaseLetters (r : Random) =
    seq [ 'A'..'Z' ] // create a sequence of chars
    |> shuffleR r // shuffle the sequence
    |> Seq.take 2 // take the first N entries from the shuffled sequence
    |> Seq.map string // convert to list of strings
    |> Seq.reduce (+) // aggregate

let mkRobot() =
    generate2RandomUpperCaseLetters rand + generateRandomStringOf3Numbers rand
    |> sprintf "%s"

let name robot = robot

let reset robot = mkRobot()