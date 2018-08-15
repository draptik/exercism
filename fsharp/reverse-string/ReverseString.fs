module ReverseString
open System.Globalization

let reverse (input: string): string =
    let si = StringInfo(input)
    Array.init si.LengthInTextElements (fun i -> si.SubstringByTextElements(i, 1))
    |> Array.rev
    |> String.concat ""


