module Darts

let distance (x : double, y : double) = sqrt ((x * x) + (y * y))

let score (x: double) (y: double): int =
    match distance (x,y) with
    | x when x <= 1.0 -> 10
    | x when x <= 5.0 -> 5
    | x when x <= 10.0 -> 1
    | _ -> 0
    