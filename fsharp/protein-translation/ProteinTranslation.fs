﻿module ProteinTranslation

open System

type DomainError =
    | InvalidRna of string

type Protein =
    | STOP
    | Methionine
    | Phenylalanine
    | Leucine
    | Serine
    | Tyrosine
    | Cysteine
    | Tryptophan
    
module Rna =
    
    type ValidRna = private ValidRna of string

    let hasExactly3Letters (s:string) : Result<string, DomainError> =
        if s.Length = 3 then Ok s
        else Error (InvalidRna "3 letters")
    
    let has3ValidLetters (s:string) =
        let validLetters = set ['A'; 'C'; 'G'; 'T'; 'U']
        if Set.isSuperset validLetters (set s) then Ok s
        else Error (InvalidRna "invalid letter")
        
    let create (unvalidatedInput:string) : Result<ValidRna, DomainError> =
        if String.IsNullOrWhiteSpace(unvalidatedInput) then
            Error (InvalidRna "empty")
        else
            unvalidatedInput
            |> hasExactly3Letters
            |> Result.bind has3ValidLetters
            |> Result.map String.Concat
            |> Result.map ValidRna 

    let value (ValidRna rna) = rna

let split (rawInput:string) =
    let codonSize = 3
    
    rawInput
    |> Seq.chunkBySize codonSize
    |> Seq.map (fun charArray -> String.Concat(charArray))
    
let mapToProtein validRna =
    match Rna.value validRna with
    | "AUG" -> Some Methionine
    | "UUU" | "UUC" -> Some Phenylalanine
    | "UUA" | "UUG" -> Some Leucine
    | "UCA" | "UCC" | "UCG" | "UCU" -> Some Serine
    | "UAU" | "UAC" -> Some Tyrosine
    | "UGU" | "UGC" -> Some Cysteine
    | "UGG" -> Some Tryptophan
    | "UAA" | "UAG" | "UGA" -> Some STOP
    | _ -> None

let createOptionalProtein resultRna =
    match resultRna with
    | Ok rna -> rna |> mapToProtein
    | Error _ -> None

let isNotStopCodon optionalProtein =
    match optionalProtein with
    | Some protein -> protein <> STOP
    | _ -> true

let optionalProteinToString optionalProtein =
    match optionalProtein with
    | Some protein -> sprintf "%A" protein
    | None -> ""
        
let proteins rna =
    split rna
    |> Seq.map Rna.create
    |> Seq.map createOptionalProtein
    |> Seq.takeWhile isNotStopCodon
    |> Seq.map optionalProteinToString
    |> Seq.toList
