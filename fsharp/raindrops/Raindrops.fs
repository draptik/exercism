module Raindrops

let convert (number: int): string =
    let genStr divisor str =
        fun (value, acc) -> 
            if value % divisor = 0 then (value, acc + str)
            else (value, acc)   

    let pling = genStr 3 "Pling"
    let plang = genStr 5 "Plang"
    let plong = genStr 7 "Plong"

    let extract x =
        match x with
        | (num, "") -> num.ToString()
        | (_, sound) -> sound

    (number, "")
    |> pling
    |> plang
    |> plong
    |> extract
