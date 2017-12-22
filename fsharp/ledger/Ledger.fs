module Ledger

open System
open System.Globalization

type Entry = { dat: DateTime; des: string; chg: int }

type Currency = EUR | USD

let getCurrencySymbol currency =
    match currency with
    | EUR -> "€"
    | USD -> "$"

let parseCurrency input =
    match input with
    | "EUR" -> EUR
    | "USD" -> USD
    | _ -> failwith "Invalid currency"

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
    let symbol = getCurrencySymbol currency

    match value < 0.0, locale with
    | true, "nl-NL" -> (symbol + " " + formattedMoney).PadLeft(13) 
    | true, "en-US" -> ("(" + symbol + formattedMoney.Substring(1) + ")").PadLeft(13) 
    | false, "nl-NL" -> (symbol + " " + formattedMoney + " ").PadLeft(13) 
    | false, "en-US" -> (symbol + formattedMoney + " ").PadLeft(13) 
    | _ -> ""

let getValue x = float x.chg / 100.0

let formatLine locale currency entry =
    "\n" + (formatDate entry.dat locale) + " | " + (formatDescription entry.des) + " | " + (prettifyMoney locale currency (getValue entry))

let formatLedger currencyInput locale entries =
    let currency = parseCurrency currencyInput

    let content =
        match entries with
        | [] -> "" 
        | _ -> 
            entries
            |> List.sortBy (fun x -> x.dat, x.des, x.chg)
            |> List.map(fun x -> formatLine locale currency x)
            |> List.reduce(( + ))

    createHeadline locale + content
