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

let formatLedger currency locale entries =
    
    let mutable res = ""

    res <- createHeadline locale
        
    for x in List.sortBy (fun x -> x.dat, x.des, x.chg) entries do

        res <- res + "\n"

        res <- res + formatDate x.dat locale
                
        res <- res + " | "

        if x.des.Length <= 25 then 
            res <- res + x.des.PadRight(25)
        elif x.des.Length = 25 then 
            res <- res + x.des
        else 
            res <- res + x.des.[0..21] + "..."

        res <- res + " | "
        let c = float x.chg / 100.0

        if c < 0.0 then 
            if locale = "nl-NL" then
                if currency = "USD" then
                    res <- res + ("$ " + c.ToString("#,#0.00", new CultureInfo("nl-NL"))).PadLeft(13) 
                if currency = "EUR" then
                    res <- res + ("€ " + c.ToString("#,#0.00", new CultureInfo("nl-NL"))).PadLeft(13) 
            if locale = "en-US" then
                if currency = "USD" then
                    res <- res + ("($" + c.ToString("#,#0.00", new CultureInfo("en-US")).Substring(1) + ")").PadLeft(13) 
                if currency = "EUR" then
                    res <- res + ("(€" + c.ToString("#,#0.00", new CultureInfo("en-US")).Substring(1) + ")").PadLeft(13) 
        else 
            if locale = "nl-NL" then
                if currency = "USD" then
                    res <- res + ("$ " + c.ToString("#,#0.00", new CultureInfo("nl-NL")) + " ").PadLeft(13) 
                if currency = "EUR" then
                    res <- res + ("€ " + c.ToString("#,#0.00", new CultureInfo("nl-NL")) + " ").PadLeft(13) 
            if locale = "en-US" then
                if currency = "USD" then
                    res <- res + ("$" + c.ToString("#,#0.00", new CultureInfo("en-US")) + " ").PadLeft(13) 
                if currency = "EUR" then
                    res <- res + ("€" + c.ToString("#,#0.00", new CultureInfo("en-US")) + " ").PadLeft(13) 
    res
