module RNATranscription

let matchDna2Rna dna =
    match dna with
    | 'C' -> 'G'
    | 'G' -> 'C'
    | 'T' -> 'A'
    | 'A' -> 'U'
    | _ -> 'x'

// Stripping input parameter

let toRna = 
    String.map matchDna2Rna
