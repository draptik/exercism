module Series

open System

type Input =
    {
        Series: string
        SliceLength: int
    }

let validateSeries input =
    if String.IsNullOrEmpty(input.Series) then None
    else Some input
    
let validateSliceLengthSmallerThanSeriesLength input =
    if input.Series.Length >= input.SliceLength then Some input
    else None

let validatePositiveSliceLength input =
    if input.SliceLength > 0 then Some input
    else None

let createSubSeries input =
    input.Series
    |> Seq.windowed input.SliceLength // <-- "windowed"...
    |> Seq.map (fun chars -> String.Concat(chars))
    |> Seq.toList
    |> Some

let slices str length =
    validateSeries ({Series = str; SliceLength = length})
    |> Option.bind validateSliceLengthSmallerThanSeriesLength
    |> Option.bind validatePositiveSliceLength
    |> Option.bind createSubSeries
