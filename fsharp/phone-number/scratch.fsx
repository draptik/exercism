open System.Text.RegularExpressions

let stripNonNumbers s =
    Regex.Replace(s, "[^0-9.]", "")

let validateLength (s:string) =
    match s.Length with
    | 10 -> Some s
    | 11 when s.[0] = '1' -> Some s
    | _ -> None

let stripCountryCode (s:string) =
    if s.Length = 11 then s.[1..10]
    else s


type Adder = int -> int
type AdderGenerator = int -> Adder

let a:AdderGenerator = fun x -> (fun y -> x + y)


// let b:AdderGenerator = fun (x:float) -> (fun y -> x + y)
// let c                = fun (x:float) -> (fun y -> x + y)