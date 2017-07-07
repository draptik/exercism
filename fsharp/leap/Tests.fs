module Tests

open System
open Xunit

let IsDividableBy number denominator =
    number % denominator = 0

let (|DividableBy|_|) denominator year = 
    if IsDividableBy year denominator then Some DividableBy 
    else None



let isLeapYear num =
    let l = [ (400,true); (100,false); (4,true); ]
    let option = 
        l |> List.tryFind(fun (denominator, _) -> IsDividableBy num denominator)
    if option.IsSome then
        let (_, result) = Option.get option
        result
    else 
        false

    // match num with
    // | DividableBy 400 -> true
    // | DividableBy 100 -> false
    // | DividableBy 4 -> true
    // | _ -> false


//
// let isLeapYear num =
//     match num with
//     | 1900 -> false
//     | 1997 -> false
//     | 2000 -> true
//     | _ -> true

[<Fact>]
let ``Is 1996 a valid leap year`` () = 
    Assert.True(isLeapYear 1996)

[<Fact>]
let ``Is 1997 an invalid leap year`` () = 
    Assert.False(isLeapYear 1997)

[<Fact>]
let ``Is the turn of the 20th century an invalid leap year`` () = 
    Assert.False(isLeapYear 1900)

[<Fact>]
let ``Is the turn of the 25th century a valid leap year`` () = 
    Assert.True(isLeapYear 2400)    