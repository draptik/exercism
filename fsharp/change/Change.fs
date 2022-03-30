module Change

// https://codereview.stackexchange.com/questions/155967/coin-change-kata-in-immutablejs
// http://howardism.org/Technical/LP/coin-kata.html

// This will only work if coins are multiples of each other
let f coins target =
    let sortedCoins = coins |> List.sortDescending
    let folder (accAmount, result) coin =
        let remainAmount = accAmount % coin
        let coinClones = accAmount / coin |> List.replicate <| coin
        remainAmount, coinClones @ result
    let init = target, []
    let remain, cs = List.fold folder init sortedCoins
    match remain, cs with
    | 0, [] -> None
    | 0, _ -> Some cs
    | _, _ -> None

// https://exercism.org/tracks/fsharp/exercises/change/solutions/11e5c0c8a72946a0b65b295da5a7cef8
let change target coins =
    
    let tryAddToPocket pocket coin =
        let changeToReturn = target - List.sum pocket
        
        if coin > changeToReturn then
            None
        else
            coin :: pocket |> List.sort |> Some
        
    let pocketsWithExtraCoin pocket =
        coins 
        |> List.choose (tryAddToPocket pocket)
        
    let rec loop pockets =
        let targetReached = 
            pockets 
            |> List.tryFind (List.sum >> (=) target)
        
        match targetReached with
        | Some p -> 
            p 
            |> List.sort 
            |> Some
        | None when List.isEmpty pockets -> 
            None
        | None ->
            pockets
            |> List.distinct
            |> List.collect pocketsWithExtraCoin
            |> loop
    
    loop [[]]
    
let findFewestCoins coins target =
    change target coins
