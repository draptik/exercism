module Change

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
