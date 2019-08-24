module HighScores

let scores (values: int list): int list =
    values

let latest (values: int list): int =
    values |> List.rev |> List.head

let personalBest (values: int list): int =
    values |> List.max

let personalTopThree (values: int list): int list =
    let maxIndex = if values.Length < 3 then values.Length - 1 else 2
    values |> List.sort |> List.rev |> fun x -> x.[0..maxIndex]