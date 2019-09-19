module ProteinTranslation

open System

type DomainError =
    | InvalidRna of string
    
module Rna =
    
    type ValidRna = private ValidRna of string

    let hasExactly3Letters (s:string) : Result<string, DomainError> =
        if s.Length = 3 then Ok s
        else Error (InvalidRna "3 letters")
    
    let has3ValidLetters (s:string) =
        let validLetters = set ['A'; 'C'; 'G'; 'T'; 'U']
        if Set.isSuperset validLetters (set s) then Ok s
        else Error (InvalidRna "invalid letter")
        
    let create (s:string) : Result<ValidRna, DomainError> =
        if String.IsNullOrWhiteSpace(s) then
            Error (InvalidRna "empty")
        else
            s
            |> hasExactly3Letters
            |> Result.bind has3ValidLetters
            |> Result.map String.Concat
            |> Result.map ValidRna 

    let value (ValidRna rna) = rna

let split (s:string) =
    s
    |> Seq.chunkBySize 3
    
let mapToProtein rna =
    match Rna.value rna with
    | "AUG" ->  "Methionine"
    | "UUU" | "UUC" ->  "Phenylalanine"
    | "UUA" | "UUG" ->  "Leucine"
    | "UCA" | "UCC" | "UCG" | "UCU" ->  "Serine"
    | "UAU" | "UAC" ->  "Tyrosine"
    | "UGU" | "UGC" ->  "Cysteine"
    | "UGG" ->  "Tryptophan"
    | _ -> "no protein found for given RNA sequence"

let proteins rna =
    let result =
        match Rna.create rna with
        | Ok x -> x |> mapToProtein
        | Error _ -> "ups"
    
    List.init 1 (fun _ -> result)
    
