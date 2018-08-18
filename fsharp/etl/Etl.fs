module Etl

let convertListOfCharsToLowerCase (xs: char list) =
    let toLower c = (string c).ToLower()
    let toChar s = (char s)

    xs |> List.map (toLower >> toChar)

let convertOldEntry oldEntry =
    let score, chars = oldEntry
    chars 
    |> convertListOfCharsToLowerCase
    |> Seq.map (fun c -> (c, score))

let convertEntries xs =
    xs
    |> Seq.collect convertOldEntry
    |> Seq.sortBy (fun (c, _) -> c)

let transform (scoresWithLetters: Map<int, char list>): Map<char, int> =
    scoresWithLetters
    |> Map.toSeq
    |> convertEntries
    |> Map.ofSeq
