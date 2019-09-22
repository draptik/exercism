module Seq

//let check f acc =
//    let rec checkImpl f acc = function
//        | [] -> []
//        | h::t -> checkImpl f (acc @ [f h]) t
//    checkImpl f [] acc
//
//check (fun x -> x * x) [1; 2; 3]
    
let keep pred xs = xs
//    check pred xs    
        

let discard pred xs = failwith "You need to implement this function."