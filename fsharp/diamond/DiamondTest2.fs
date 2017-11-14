module DiamondProperties

// Following along Ploeh's Pluralsight course...

open System
open FsCheck
open FsCheck.Xunit
open FsCheck

let make letter = "Devil's advocat"


type Letters =
    static member Chars () =
        Arb.Default.Char()
        |> Arb.filter (fun c -> 'A' <= c && c <= 'Z')


[<Property(Arbitrary = [| typeof<Letters> |])>]
let ``Dimaond is non empty`` (letter: char) =
    printfn "%c" letter
    let actual = make letter
    not (String.IsNullOrWhiteSpace actual)

