module Pangram

open System
open System.Text.RegularExpressions

let allValidChars = [ 'a'..'z' ]

let reduceToLowerCase coll =
    coll
    |> Seq.map(fun x -> x.ToString().ToLower())

let removeNonLowerAlphaChars l =
    l
    |> Seq.map(fun x ->
        match Regex.Match(x, "/[a-z]/)") with
        | x -> "a"
        | _ -> "b")


let isPangram (input: string): bool =
    true