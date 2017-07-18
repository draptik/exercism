module RNATranscriptionTest

open Xunit

open RNATranscription

[<Fact>]
let ``Rna complement of cytosine is guanine`` () =
    Assert.Equal("G", toRna "C")

[<Fact>]
let ``Rna complement of guanine is cytosine`` () =
    Assert.Equal("C", toRna "G")

[<Fact>]
let ``Rna complement of thymine is adenine`` () =
    Assert.Equal("A", toRna "T")

[<Fact>]
let ``Rna complement of adenine is uracil`` () =
    Assert.Equal("U", toRna "A")

[<Fact>]
let ``Rna complement`` () =
    Assert.Equal("UGCACCAGAAUU", toRna "ACGTGGTCTTAA")