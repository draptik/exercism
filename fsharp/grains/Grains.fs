module Grains

let validSquares = [1..64]
let isValidSquare n = validSquares |> Seq.contains n

let square (n: int): Result<uint64,string> =
    if not (isValidSquare n) then Error "square must be between 1 and 64"
    else if n = 1 then Ok 1UL
    else Ok (uint64 (float (2) ** (float (n-1))))
    
let total: Result<uint64,string> =

    let extractOnlyOks (results: Result<uint64, string> seq) =
        results
        |> Seq.map (
                     fun result ->
                         match result with
                         | Ok num -> num
                         | _ -> 0UL)
                
    let sumOfValidSquares =
        validSquares
        |> Seq.map square
        |> extractOnlyOks
        |> Seq.sum

    Ok sumOfValidSquares