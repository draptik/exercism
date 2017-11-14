module DiamondProperties

// Following along Ploeh's Pluralsight course...

open System
open FsCheck.Xunit

let make letter = "Devil's advocat"

[<Property>]
let ``Dimaond is non empty`` (letter: char) =
    let actual = make letter
    not (String.IsNullOrWhiteSpace actual)

