module RNATranscription

// let matchDna2Rna dna =
//     match dna with
//     | 'C' -> 'G'
//     | 'G' -> 'C'
//     | 'T' -> 'A'
//     | 'A' -> 'U'
//     | _ -> 'x'

let toRna dnaNucleotid =
    match dnaNucleotid with
    | "C" -> "G"
    | "G" -> "C"
    | "T" -> "A"
    | "A" -> "U"
    | _ -> ""
