module BeerSong

let capitalize (s: string) =
    match s with
    | "" -> ""
    | s when s.[0] >= 'a' && s.[0] <= 'z' ->
        s.Remove(0, 1).Insert(0, string (char (int s.[0] - 32)))
    | _ -> s

let finalFirstLine = "No more bottles of beer on the wall, no more bottles of beer."
let finalSecondLine = "Go to the store and buy some more, 99 bottles of beer on the wall."

let finalVerse = [finalFirstLine; finalSecondLine]

let genericVerse number =
    let bottlesOfBeer n =
        match n with
        | 0 -> "no more bottles"
        | 1 -> "1 bottle"
        | _ ->  $"{n} bottles"
    
    let takedown n = if n = 1 then "it" else "one"
    
    let firstLine = $"{bottlesOfBeer number |> capitalize} of beer on the wall, {bottlesOfBeer number} of beer."
    let secondLine = $"Take {takedown number} down and pass it around, {bottlesOfBeer (number-1)} of beer on the wall."
    [firstLine; secondLine]

let multipleVerses startBottles takeDown =
    if takeDown > 1 then
        genericVerse startBottles
    else
        genericVerse startBottles
    
    
let recite (startBottles: int) (takeDown: int) =
    if startBottles = 0 then
        finalVerse
    else
        multipleVerses startBottles takeDown
