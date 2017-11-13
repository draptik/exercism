module Phrase

open System

let wordCount (phrase: string) =
    let words = phrase.Split(" ")

    words
    |> Seq.countBy (fun x -> x.Trim())
    |> Map.ofSeq
