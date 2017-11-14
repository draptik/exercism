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
let ``Dimaond is non empty`` (letter : char) =
    // printfn "%c" letter
    let actual = make letter
    not (String.IsNullOrWhiteSpace actual)

[<DiamondProperty>]
let ``First row contains 'A'`` (letter : char) =
    let actual = make letter
    let rows = split actual

    // Note: 
    // - A string is a sequence (`Seq`) of characters
    // - The 1st entry in a sequence is `Seq.head`
    rows |> Seq.head |> Seq.exists ((=) 'A')
