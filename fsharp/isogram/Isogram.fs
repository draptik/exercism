module Isogram

open System

let isIsogramInternalV1 (str : string) =
    str
    |> Seq.map Char.ToLowerInvariant // map all strings to lowercase char array
    |> Seq.filter Char.IsLetter // we only care about letters
    |> Seq.toList
    |> List.groupBy id // group by identity (duplicates are grouped: "aba" -> [('a', ['a'; 'a']); ('b', ['b'])])
    |> List.map snd // we only care about duplicate entries (array within array): "aba" -> [['a'; 'a']; ['b']]
    |> List.filter (fun set -> set.Length > 1) // strip all non-duplicates: "aba" -> [['a'; 'a']]
    |> List.map (fun set -> set.[0]) // only take the first entry
    |> List.length = 0 // length > 0 means we have duplicates (not an isogram)

let isIsogram str =
    isIsogramInternalV1 str