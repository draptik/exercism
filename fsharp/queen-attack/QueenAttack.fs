module QueenAttack
open System

let create (position: int * int) =

    let internal_create (x:int, y: int) =
        x > 0 && x < 8 && y > 0 && y < 8

    internal_create position

let canAttack (queen1: int * int) (queen2: int * int) =

    let internal_canAttack (x1:int, y1:int) (x2:int, y2:int) =
        if x1 = x2 then true
        else if y1 = y2 then true
        else Math.Abs(x1 - x2) = Math.Abs(y1 - y2)

    internal_canAttack queen1 queen2
