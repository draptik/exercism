module Anagram
open System

let sort (s: string) =
    s
    |> seq
    |> Seq.sort
    |> String.Concat

let isAnagram (s1: string) (s2: string) =
    let s1' = s1.ToLowerInvariant()
    let s2' = s2.ToLowerInvariant()
    not (s1' = s2') && (sort s1') = (sort s2')

let findAnagrams sources target =
    sources
    |> List.filter (isAnagram target)
