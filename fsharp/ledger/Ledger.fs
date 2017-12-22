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

type Locale = EN | NL

let parseLocale input =
    match input with
    | "en-US" -> EN
    | "nl-NL" -> NL
    | _ -> failwith "Invalid locale"

let culture locale =
    match locale with
    | EN -> CultureInfo("en-US") 
    | NL -> CultureInfo("nl-NL")

let mkEntry date description change = { dat = DateTime.Parse(date, CultureInfo.InvariantCulture); des = description; chg = change }

let createHeadline locale =
    match locale with
    | EN -> "Date       | Description               | Change       "
    | NL -> "Datum      | Omschrijving              | Verandering  "

let formatDate (date:DateTime) locale =
    match locale with
    | NL -> date.ToString("dd-MM-yyyy")
    | EN -> date.ToString("MM\/dd\/yyyy")

let formatDescription (description:string) =
    match description with
    | d when d.Length <= 25 -> description.PadRight(25)
    | d when d.Length = 25 -> description
    | _ -> description.[0..21] + "..."

let formatMoney locale (value:float) = value.ToString("#,#0.00", culture locale)

let prettifyMoney locale currency value =
    let formattedMoney = formatMoney locale value
    let symbol = getCurrencySymbol currency

    match value < 0.0, locale with
    | true, NL -> (symbol + " " + formattedMoney).PadLeft(13) 
    | true, EN -> ("(" + symbol + formattedMoney.Substring(1) + ")").PadLeft(13) 
    | false, NL -> (symbol + " " + formattedMoney + " ").PadLeft(13) 
    | false, EN -> (symbol + formattedMoney + " ").PadLeft(13) 

let getValue x = float x.chg / 100.0

let formatLine locale currency entry =
    "\n" + (formatDate entry.dat locale) + " | " + (formatDescription entry.des) + " | " + (prettifyMoney locale currency (getValue entry))

let formatLedger currencyInput localeInput entries =
    let currency = parseCurrency currencyInput
    let locale = parseLocale localeInput

    let content =
        match entries with
        | [] -> "" 
        | _ -> 
            entries
            |> List.sortBy (fun x -> x.dat, x.des, x.chg)
            |> List.map(fun x -> formatLine locale currency x)
            |> List.reduce(( + ))

    createHeadline locale + content
