module Change

// https://codereview.stackexchange.com/questions/155967/coin-change-kata-in-immutablejs
//let foo denominations amount =
//    denominations
//    |> List.reduce (fun acc elem ->
//        let remainder = acc
//        )

// http://howardism.org/Technical/LP/coin-kata.html
let rec f (money : int) (coins : int list) : int =
    let availableCoins = coins |> List.filter (fun x -> x <= money)
    
    if money = 0 then
        1
    else if money < 0 then
        0
    else if availableCoins.Length = 0 then
        0
    else
        f (money - coins.Head) coins + f money coins.Tail

let countChange money coins =
    if money = 0 then
        0
    else
        f money (coins |> List.rev)

let findFewestCoins coins target =

    if List.contains target coins then
        Some [target]
    else
        None
