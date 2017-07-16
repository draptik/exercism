module RNATranscriptionTest

open Xunit

open RNATranscription

[<Fact>]
let ``Rna complement of cytosine is guanine`` () =
    
    Assert.That(toRna "C", Is.EqualTo("G"))

[<Fact>]
[<Ignore("Remove to run test")>]
let ``Rna complement of guanine is cytosine`` () =
    Assert.That(toRna "G", Is.EqualTo("C"))

[<Fact>]
[<Ignore("Remove to run test")>]
let ``Rna complement of thymine is adenine`` () =
    Assert.That(toRna "T", Is.EqualTo("A"))

[<Fact>]
[<Ignore("Remove to run test")>]
let ``Rna complement of adenine is uracil`` () =
    Assert.That(toRna "A", Is.EqualTo("U"))

[<Fact>]
[<Ignore("Remove to run test")>]
let ``Rna complement`` () =
    Assert.That(toRna "ACGTGGTCTTAA", Is.EqualTo("UGCACCAGAAUU"))