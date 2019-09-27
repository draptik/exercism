module Isogram

open System

let isIsogram str =
    let toLetters (s: string) =
        s
        |> Seq.map Char.ToLowerInvariant
        |> Seq.filter Char.IsLetter

    let inputLength = str |> toLetters |> Seq.length 

    let checkedLength =
        str
        |> toLetters
        |> Seq.distinct
        |> Seq.length
    
    checkedLength = inputLength 
