module Accumulate
    
let accumulate (func: 'a -> 'b) (input: 'a list): 'b list =
    
    let rec acc f items =
        match items with
        | [] -> []
        | head :: tail -> (f head) :: (acc f tail)
    
    acc func input