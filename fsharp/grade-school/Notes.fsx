// Creating a Map of type <int, string list>
Map.ofList [ (1, ["one0"; "one1" ]) ]

// Manipulating an immutable Map
//
// - adding something to the list collection
Map.ofList [ (1, ["one0"; "one1" ]) ]
    |> Map.map (fun key value -> List.append value ["x"])
// returns:
// val it : Map<int,string list> = map [(1, ["one0"; "one1"; "x"])]

// - adding something to the beginning of the list collection
Map.ofList [ (1, ["one0"; "one1" ]) ]
    |> Map.map (fun key value -> "x" :: value)
// returns:
// val it : Map<int,string list> = map [(1, ["x"; "one0"; "one1"])]

// Converting a "Map<int, string list>" to Tuple list: "(int * string list) list"
Map.ofList [ (1, ["one0"; "one1" ]) ]
    |> Map.toList
