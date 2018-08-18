module Etl

let convertListOfCharsToLowerCase (xs: char list) =
    xs
    |> Seq.map (fun x -> (string x).ToLower())
    |> Seq.map (fun x -> (char x))

let convertOldEntry oldEntry =
    let score, chars = oldEntry
    chars 
    |> convertListOfCharsToLowerCase
    |> Seq.map (fun c -> (c, score))

let convertEntries xs =
    xs
    |> Seq.collect convertOldEntry
    |> Seq.sortBy (fun (c, _) -> c)
    |> List.ofSeq

let transform (scoresWithLetters: Map<int, char list>): Map<char, int> =
    scoresWithLetters
    |> Map.toSeq
    |> convertEntries
    |> Map.ofList    
