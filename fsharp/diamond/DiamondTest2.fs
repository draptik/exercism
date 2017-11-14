module DiamondProperties

// Following along Ploeh's Pluralsight course...

open System
open FsCheck
open FsCheck.Xunit

let make letter = //"      A      "
    ['A' .. letter]
    |> List.map (fun x -> x.ToString())
    |> List.reduce (fun x y -> 
        sprintf "%s%s%s" x Environment.NewLine y)



type Letters =
    static member Chars () =
        Arb.Default.Char()
        |> Arb.filter (fun c -> 'A' <= c && c <= 'Z')

type DiamondPropertyAttribute () =
    inherit PropertyAttribute(Arbitrary = [| typeof<Letters> |])

let split (s : string) =
    s.Split([| Environment.NewLine |], StringSplitOptions.None)

let trim (s : string) = s.Trim()

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
    rows |> Seq.head |> trim = "A"

let leadingSpaces (x : string) =
    let indexOfNonSpace = x.IndexOfAny [| 'A' .. 'Z' |]
    x.Substring(0, indexOfNonSpace)

let trailingSpaces (x : string) =
    let lastIndexOfNonSpace = x.LastIndexOfAny [| 'A' .. 'Z' |]
    x.Substring(lastIndexOfNonSpace + 1)

[<DiamondProperty>]
let ``All rows must have a symmetric contour`` (letter : char) =
    let actual = make letter

    let rows = split actual
    rows |> Array.forall (fun r -> (leadingSpaces r) = (trailingSpaces r))

[<DiamondProperty>]
let ``Top of figure has correct letters in correct order`` (letter : char) =
    let actual = make letter
    printfn "%s" actual

    let expected = ['A' .. letter]
    let rows = split actual
    
    let firstNonWhiteSpaceLetters =
        rows
        |> Seq.take expected.Length // take as many rows as expected entries
        |> Seq.map trim // remove all whitespace from each row
        |> Seq.map Seq.head // take first char of each row
        |> Seq.toList // convert to list

    expected = firstNonWhiteSpaceLetters
