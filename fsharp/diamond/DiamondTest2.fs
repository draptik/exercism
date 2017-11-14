module DiamondProperties

// Following along Ploeh's Pluralsight course...

open System
open FsCheck
open FsCheck.Xunit

let make letter =
    let makeLine letterCount (letter, letterIndex) =
        let leadingSpaces = String(' ', letterCount - 1 - letterIndex)
        match letter with
        | 'A' ->
            sprintf "%s%c%s" leadingSpaces letter leadingSpaces
        | _ ->
            let left = sprintf "%c%s" letter leadingSpaces |> Seq.toList
            left
            @ (left |> List.rev |> List.tail)
            |> List.map string
            |> List.reduce (sprintf "%s%s")

    let letters = ['A' .. letter] |> List.mapi (fun i l -> l, i)

    letters
    @ (letters |> List.rev |> List.tail)
    |> List.map (makeLine letters.Length)
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
    let actual = make letter
    not (String.IsNullOrWhiteSpace actual)

[<DiamondProperty>]
let ``First row contains 'A'`` (letter : char) =
    let actual = make letter
    let rows = split actual
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
    let expected = ['A' .. letter]
    let rows = split actual
    
    let firstNonWhiteSpaceLetters =
        rows
        |> Seq.take expected.Length
        |> Seq.map (trim >> Seq.head)
        |> Seq.toList

    expected = firstNonWhiteSpaceLetters

[<DiamondProperty>]
let ``Figure is symmetric around the horizontal axis`` (letter : char) =
    let actual = make letter
    let rows = split actual
    
    let topRows =
        rows
        // get all rows which do not contain `letter`:
        |> Seq.takeWhile (fun x -> not (x.Contains(string letter)))
        |> Seq.toList
    
    let bottomRows =
        rows
        // get all rows below diamond horizontal axis:
        |> Seq.skipWhile (fun x -> not (x.Contains(string letter)))
        |> Seq.skip 1
        |> Seq.toList
        |> List.rev
    
    topRows = bottomRows

[<DiamondProperty>]
let ``Diamond is as wide as it is high`` (letter : char) =
    let actual = make letter
    let rows = split actual
    
    let expected = rows.Length
    rows |> Array.forall (fun x -> x.Length = expected)

[<DiamondProperty>]
let ``All rows except top and bottom have 2 identical letters`` (letter : char) =
    let actual = make letter
    let rows = split actual
    
    let isTwoIdenticalLetters x =
        let hasIdenticalLetters = x |> Seq.distinct |> Seq.length = 1
        let hasTwoLetters = x |> Seq.length = 2
        hasIdenticalLetters && hasTwoLetters

    rows
    |> Array.filter (fun x -> not (x.Contains("A")))
    |> Array.map (fun x -> x.Replace(" ", ""))
    |> Array.forall isTwoIdenticalLetters

[<DiamondProperty>]
let ``Lower left space is a triangle`` (letter : char) =
    let actual = make letter
    let rows = split actual

    let lowerLeftSpace =
        rows
        |> Seq.skipWhile (fun x -> not (x.Contains(string letter)))
        |> Seq.map leadingSpaces
        |> Seq.toList
    
    let spaceCounts = lowerLeftSpace |> List.map (fun x -> x.Length)

    let expected =
        Seq.initInfinite id
        |> Seq.take spaceCounts.Length
        |> Seq.toList

    expected = spaceCounts
