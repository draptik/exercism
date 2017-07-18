module RNATranscription

let matchDna2Rna dna =
    match dna with
    | 'C' -> 'G'
    | 'G' -> 'C'
    | 'T' -> 'A'
    | 'A' -> 'U'
    | _ -> 'x'

// Using String.map with explicit signature
let toRna (input:string) : string =
    String.map matchDna2Rna input
