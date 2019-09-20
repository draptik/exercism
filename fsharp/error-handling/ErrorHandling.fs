module ErrorHandling
open System

let handleErrorByThrowingException() = failwith "ups"

let handleErrorByReturningOption input =
    if input = "1" then Some 1
    else None

let handleErrorByReturningResult input =
    if input = "1" then Ok 1
    else Error "Could not convert input to integer"

let bind switchFunction twoTrackInput =
    match twoTrackInput with
    | Ok x -> switchFunction x
    | Error e -> Error e

let cleanupDisposablesWhenThrowingException resource =
    use r = resource
    failwith "ups"