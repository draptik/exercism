module Series

open System

let validateSeries data =
    let (series, _) = data
    if String.IsNullOrEmpty(series) then None
    else Some data
    
let validateSliceLength data =
    let (series: string, slice) = data
    if series.Length < slice then None
    else Some data

let validatePositiveSliceLength data =
    let (_, slice) = data
    if slice > 0 then Some data
    else None

let createSubSeries data =
    let (series: string, slice) = data
    series
    |> Seq.windowed slice
    |> Seq.map (fun chars -> String.Concat(chars))
    |> Seq.toList
    |> Some

let slices str length =
//    let optionalInputValidation =
//        validateSeries (str, length)
//        |> Option.bind validateSliceLength
//        |> Option.bind validatePositiveSliceLength
//        
//    match optionalInputValidation with
//    | None -> None
//    | Some data -> createSubSeries data |> Some

    validateSeries (str, length)
    |> Option.bind validateSliceLength
    |> Option.bind validatePositiveSliceLength
    |> Option.bind createSubSeries
