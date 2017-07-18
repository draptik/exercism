module RNATranscription

let matchDna2Rna dna =
    match dna with
    | 'C' -> 'G'
    | 'G' -> 'C'
    | 'T' -> 'A'
    | 'A' -> 'U'
    | _ -> 'x'

// Using String.map with implicit signature
let toRna dna = 
    String.map matchDna2Rna dna

