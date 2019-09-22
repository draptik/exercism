module Acronym

open System
open System.Text.RegularExpressions

let abbreviate (phrase:string) =
    // there is probably a nicer way to do this...
    let phrase' = phrase.Replace("'", "").Replace("_", "")

    Regex.Matches(phrase', @"\b(\w)")
    |> Seq.cast<Match> // <-- important!
    |> Seq.map (fun x -> x.Value)
    |> Seq.map (fun x -> x.ToUpper())
    |> String.Concat
