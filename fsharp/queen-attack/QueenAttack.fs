module QueenAttack
open System

let create (position: int * int) =
    let (x, y) = position
    x > 0 && x < 8 && y > 0 && y < 8    

let canAttack (queen1: int * int) (queen2: int * int) =
    let ((x1, y1), (x2, y2)) = (queen1, queen2)
    if x1 = x2 then true
    else if y1 = y2 then true
    else Math.Abs(x1 - x2) = Math.Abs(y1 - y2)
