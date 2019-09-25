module Isogram

open System

let isIsogram str =
    let toLetters (s: string) =
        s
        |> Seq.map Char.ToLowerInvariant
        |> Seq.filter Char.IsLetter

    let inputLength = str |> toLetters |> Seq.length 
    
    str
    |> toLetters
    |> Seq.sort
    |> Seq.distinct
    |> Seq.length = inputLength 
