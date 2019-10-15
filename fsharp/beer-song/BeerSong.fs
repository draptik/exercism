module BeerSong

let toLower (s: string) = s.ToLower()

let stateLine startBottles =
    let bottle =
        match startBottles with
        | 0 -> "No more bottles"
        | 1 -> "1 bottle"
        | _ -> sprintf "%i bottles" startBottles 
    sprintf "%s of beer on the wall, %s of beer." bottle (toLower bottle) 

let actionLine startBottles =
    if startBottles = 0 then
        "Go to the store and buy some more, 99 bottles of beer on the wall."
    else
        let reducedCount = startBottles - 1
        let bottle =
            match reducedCount with
            | 0 -> "no more bottles"
            | 1 -> sprintf "%i bottle" reducedCount
            | _ -> sprintf "%i bottles" reducedCount
        
        let take = if reducedCount = 0 then "it" else "one"
        sprintf "Take %s down and pass it around, %s of beer on the wall." take bottle
    
let recite (startBottles: int) (takeDown: int) =
    [ stateLine startBottles;
      actionLine startBottles ]