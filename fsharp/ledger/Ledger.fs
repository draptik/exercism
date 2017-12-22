module Ledger

open System
open System.Globalization

type Entry = { dat: DateTime; des: string; chg: int }

let mkEntry date description change = { dat = DateTime.Parse(date, CultureInfo.InvariantCulture); des = description; chg = change }

let createHeadline locale =
    match locale with
    | "en-US" -> "Date       | Description               | Change       "
    | "nl-NL" -> "Datum      | Omschrijving              | Verandering  "
    | _ -> ""

let formatDate (date:DateTime) locale =
    match locale with
    | "nl-NL" -> date.ToString("dd-MM-yyyy")
    | "en-US" -> date.ToString("MM\/dd\/yyyy")
    | _ -> ""

let formatDescription (description:string) =
    match description with
    | d when d.Length <= 25 -> description.PadRight(25)
    | d when d.Length = 25 -> description
    | _ -> description.[0..21] + "..."

let formatMoney (locale:string) (value:float) = value.ToString("#,#0.00", CultureInfo(locale))

let prettifyMoney locale currency value =
    let formattedMoney = formatMoney locale value

    match value < 0.0, locale, currency with
    | true, "nl-NL", "USD" -> ("$ " + formattedMoney).PadLeft(13) 
    | true, "nl-NL", "EUR" -> ("€ " + formattedMoney).PadLeft(13) 
    | true, "en-US", "USD" -> ("($" + formattedMoney.Substring(1) + ")").PadLeft(13) 
    | true, "en-US", "EUR" -> ("(€" + formattedMoney.Substring(1) + ")").PadLeft(13) 
    | false, "nl-NL", "USD" -> ("$ " + formattedMoney + " ").PadLeft(13) 
    | false, "nl-NL", "EUR" -> ("€ " + formattedMoney + " ").PadLeft(13) 
    | false, "en-US", "USD" -> ("$" + formattedMoney + " ").PadLeft(13) 
    | false, "en-US", "EUR" -> ("€" + formattedMoney + " ").PadLeft(13) 
    | _ -> ""

let getValue x = float x.chg / 100.0

let formatLine locale currency entry =
    "\n" + (formatDate entry.dat locale) + " | " + (formatDescription entry.des) + " | " + (prettifyMoney locale currency (getValue entry))

let formatLedger currency locale entries =
    let content =
        match entries with
        | [] -> "" 
        | _ -> 
            entries
            |> List.sortBy (fun x -> x.dat, x.des, x.chg)
            |> List.map(fun x -> formatLine locale currency x)
            |> List.reduce(( + ))

    createHeadline locale + content
