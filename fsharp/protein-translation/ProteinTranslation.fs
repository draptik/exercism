module ProteinTranslation

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
    |> Seq.map (fun ca -> String.Concat(ca))
    
let mapToProtein rna =
    match Rna.value rna with
    | "AUG" -> Some Methionine
    | "UUU" | "UUC" -> Some Phenylalanine
    | "UUA" | "UUG" -> Some Leucine
    | "UCA" | "UCC" | "UCG" | "UCU" -> Some Serine
    | "UAU" | "UAC" -> Some Tyrosine
    | "UGU" | "UGC" -> Some Cysteine
    | "UGG" -> Some Tryptophan
    | "UAA" | "UAG" | "UGA" -> Some STOP
    | _ -> None

let proteins rna =
    
    let optProteins =
        split rna
        |> Seq.map Rna.create
        |> Seq.map (fun r ->
                    match r with
                    | Ok x -> x |> mapToProtein
                    | Error _ -> None)
    
    optProteins // seq Protein option
    |> Seq.takeWhile (fun optP ->
        match optP with
        | Some p -> p <> STOP
        | _ -> true)
    |> Seq.map (fun optP ->
        match optP with
        | Some p -> sprintf "%A" p
        | None -> "")
    |> Seq.toList
    
//    let result =
//        match Rna.create rna with
//        | Ok x -> x |> mapToProtein
//        | Error _ -> "ups"
//    
//    if result = "STOP" then
//        List.empty
//    else
//        List.init 1 (fun _ -> result)
//    
