module ArmstrongNumbers
open System

let isArmstrongNumber (number: int): bool =
    
    let digits = number.ToString() |> Seq.map (fun x -> Int32.Parse(x.ToString()))
    let numberOfDigits = number.ToString().Length
    
    let powers = seq {
        for d in digits -> (float d) ** (float numberOfDigits)    
        }
    
    let sumOfPowers = Seq.sum powers
    
    let isArmstrong n = sumOfPowers = n
        
    match number with
    | x when x < 10 && x > 0 -> true
    | x when x >= 10 && x < 100 -> false
    | x -> isArmstrong (float x)
    