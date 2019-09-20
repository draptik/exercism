module ScrabbleScore

open System

let letterValue character =
    match character with
    | 'A' | 'E' | 'I' | 'O' | 'U' | 'L' | 'N' | 'R' | 'S' | 'T' -> 1
    | 'D' | 'G' -> 2
    | 'B' | 'C' | 'M' | 'P' -> 3
    | 'F' | 'H' | 'V' | 'W' | 'Y' -> 4
    | 'K' -> 5
    | 'J' | 'X' -> 8
    | 'Q' | 'Z' -> 10
    | _ -> 0
    
let score word =
    word
    |> seq
    |> Seq.map Char.ToUpper
    |> Seq.map letterValue
    |> Seq.sum