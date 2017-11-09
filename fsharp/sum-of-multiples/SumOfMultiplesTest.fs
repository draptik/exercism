module SumOfMultiplesTest

open Xunit
open SumOfMultiples

[<Fact>]
let ``Sum to 1`` () =
    Assert.Equal(sumOfMultiples [3; 5] 0, 0)

// [<Fact>]
// let ``Sum to 3`` () =
//     Assert.Equal(sumOfMultiples [3; 5] 3, 0)

// [<Fact>]
// let ``Sum to 4`` () =
//     Assert.Equal(sumOfMultiples [3; 5] 4, 3)

// [<Fact>]
// let ``Sum to 10`` () =
//     Assert.Equal(sumOfMultiples [3; 5] 10, 23)

// [<Fact>]
// let ``Sum to 20`` () =
//     Assert.Equal(sumOfMultiples [7; 13; 17] 20, 51)

// [<Fact>]
// let ``Sum to 10000`` () =
//     Assert.Equal(sumOfMultiples [43; 47] 10000, 2203160)
