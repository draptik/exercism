module Raindrops

let factors number = seq {
    for divisor in 1 .. (float >> sqrt >> int) number do
    if number % divisor = 0 then
        yield divisor

        //special case condition: when number=1 then divisor=(number/divisor), so don't repeat it
        if number <> 1 then yield number / divisor 
}

let applyRule num =
    match num = 3, num = 5, num = 7 with
    | true, _, _ -> Some "Pling"
    | _, true, _ -> Some "Plang"
    | _, _, true -> Some "Plong"
    | _ -> None

let replace numbers =
    let sound =
        numbers
        |> Seq.map applyRule
        |> Seq.choose id
        |> Seq.distinct
        |> String.concat ""
    if sound = "" then
        let maxNumber = Seq.max numbers
        maxNumber.ToString()
    else
        sound

let convert (number: int): string =
    factors number
    |> replace