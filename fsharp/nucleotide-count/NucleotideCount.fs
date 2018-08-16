module NucleotideCount

// // Usage: count 'a' "aba" (returns 2)
// let count x = Seq.filter ((=) x) >> Seq.length

// // Usage: count2 'a' "aba" (returns 2)
// let count2 x xs =
//     xs
//     |> Seq.filter (fun x' -> x' = x)
//     |> Seq.length

// let count3 xs x =
//     xs
//     |> Seq.filter (fun x' -> x' = x)
//     |> Seq.length
let nucleotides = ['A';'C';'T';'G']

let emptyMap = 
    nucleotides
    |> List.map (fun n -> (n,0)) 
    |> Map.ofList

let nucleotideCounts' strand = 
    strand
    |> Seq.countBy id
    |> Seq.fold 
        (fun acc (nucleotide, count) -> acc |> Map.add nucleotide count) 
        emptyMap

let isValid chars s = String.forall (fun c -> List.contains c chars) s

let nucleotideCounts (strand: string): Option<Map<char, int>> =
  if isValid nucleotides strand then nucleotideCounts' strand |> Some
  else None
