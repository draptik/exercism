module DiamondProperties

// Following along Ploeh's Pluralsight course...

open System
open FsCheck
open FsCheck.Xunit

let make letter = "Devil's advocat"


type Letters =
    static member Chars () =
        Arb.Default.Char()
        |> Arb.filter (fun c -> 'A' <= c && c <= 'Z')

type DiamondPropertyAttribute () =
    inherit PropertyAttribute(Arbitrary = [| typeof<Letters> |])

let split (s : string) =
    s.Split([| Environment.NewLine |], StringSplitOptions.None)

[<DiamondProperty>]
let ``Dimaond is non empty`` (letter: char) =
    // printfn "%c" letter
    let actual = make letter
    not (String.IsNullOrWhiteSpace actual)

