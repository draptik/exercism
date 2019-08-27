module Accumulate

// copied from:
// https://blog.ploeh.dk/2015/12/22/tail-recurse/

let rec mapNotTailRecursive f = function
    | [] -> []
    | h::t -> f h :: mapNotTailRecursive f t

let mapTailRecursiveUsingAppend f xs =
    
    let rec mapImp f acc = function
        | [] -> acc
        | h::t -> mapImp f (acc @ [f h]) t
    
    mapImp f [] xs

let mapTailRecursiveUsingRev f xs =
    let rec mapImp f acc = function
        | [] -> acc
        | h::t -> mapImp f (f h :: acc) t
    mapImp f [] xs |> List.rev
    
let accumulate (func: 'a -> 'b) (input: 'a list): 'b list =
    
    // TODO: understand / debug / performance test difference approaches        
    input
//    |> mapNotTailRecursive func 
//    |> mapTailRecursiveUsingAppend func 
    |> mapTailRecursiveUsingRev func