module Pangram

let allValidChars = set [ 'a'..'z' ]

let isPangram (input: string): bool =
    input.ToLowerInvariant()
    |> set // <-- convert to Set
    |> Set.isSubset allValidChars
    