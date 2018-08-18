let concat xs =
    xs |> List.fold (fun acc x -> acc + (string x)) "" 

let sum0 xs =
    xs |> List.fold (fun acc x -> acc + x) 0

let sum1 xs =
    xs |> List.fold (+) 0

let sum2 (xs: int list) =
    List.sum xs

let deconstruct0 tuple =
    let (x,y) = tuple
    sprintf "x: %A, y: %A" x y

type AdditionFunction = int->int->int
let f:AdditionFunction = fun a b -> a + b




type Foo = int * char list -> string

let foo:Foo = fun (score, chars) ->
    ""

let foo1 tuple =
    let score, chars = tuple
    chars
    |> Seq.unfold 

let convertListOfCharsToLowerCase (xs: char list) =
    let toLower c = (string c).ToLower()
    let toChar s = (char s)

    xs
    |> List.map (toLower >> toChar)

['A'; 'B'; 'C'; 'd'] |> convertListOfCharsToLowerCase

let convertListToTupleOfThingAndInt xs =
    let someInt = 1
    xs
    |> List.map (fun x -> (x, someInt))

['A'; 'B'; 'C'; 'd'] |> convertListToTupleOfThingAndInt

['A'; 'B'; 'C'; 'd'] 
|> convertListOfCharsToLowerCase 
|> convertListToTupleOfThingAndInt

let singleEntryLettersByScore = (1, ['A'; 'E'; 'I'; 'O'; 'U'])

let convertOldEntry oldEntry =
    let score, chars = oldEntry
    chars 
    |> convertListOfCharsToLowerCase
    |> List.map (fun c -> (c, score))

singleEntryLettersByScore |> convertOldEntry


let lettersByScore = 
    [ (1, ['A'; 'E']);
      (2, ['D'; 'G']) ]

let convertEntries xs =
    xs
    |> Seq.map convertOldEntry
    |> Seq.concat

let convertEntries2 xs =
    xs
    |> Seq.collect convertOldEntry
    |> List.ofSeq

let convertEntries3 xs =
    xs
    |> Seq.collect convertOldEntry
    |> Seq.sortBy (fun (c, _) -> c)
    |> List.ofSeq

lettersByScore 
|> convertEntries3


let convertMapToSeq m = m |> Map.toSeq

let convertSeqToMap s = s |> Map.ofSeq    
