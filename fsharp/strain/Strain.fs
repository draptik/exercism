module Seq

let cheating pred xs =
    xs |> Seq.filter pred

// https://stackoverflow.com/a/32812776/1062607
// NOT tail recursive!
let rec filterRecursive f = function
    | [] -> []
    | head::tail ->
        if f head then head :: filterRecursive f tail
        else filterRecursive f tail

// https://stackoverflow.com/a/32815491/1062607
let filterFoldBack pred xs =
    List.foldBack
        (fun x acc ->
            if pred x then x::acc
            else acc)
        xs
        []

let filterFold pred xs =
    List.fold
        (fun acc x  ->
            if pred x then x::acc
            else acc)
        []
        xs
    |> List.rev

let keep pred xs =
//    cheating pred xs // using built-in `filter` function

    xs
    |> seq
    |> Seq.toList
//    |> filterRecursive pred // version 1
//    |> filterFoldBack pred // version 2
    |> filterFold pred // version 3

let discard pred xs =
    let negatedPredicate = pred >> not
    keep negatedPredicate xs