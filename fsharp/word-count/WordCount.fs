module Phrase

open System.Text.RegularExpressions
 
let wordCount phrase =
    Regex.Matches(phrase, @"\w+('\w+)*")
    |> Seq.cast<Match>
    |> Seq.countBy(fun m -> m.Value.ToLowerInvariant())
    |> Map.ofSeq