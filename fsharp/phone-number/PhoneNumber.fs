module PhoneNumber

open System.Text.RegularExpressions

let stripNonNumbers s =
    Regex.Replace(s, "[^0-9.]", "")

let stripDots s =
    Regex.Replace(s, "\.", "")

let stripLeadingUSCountryCode (s:string) =
    if s.Length = 11 && s.[0] = '1' then s.[1..10]
    else s

let validateLength (s:string) =
    if s.Length = 10 then Some s
    else None

let clean input =
    input
    |> stripNonNumbers
    |> stripDots
    |> stripLeadingUSCountryCode
    |> validateLength
