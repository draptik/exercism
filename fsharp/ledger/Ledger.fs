﻿module Ledger

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
    if description.Length <= 25 then 
        description.PadRight(25)
    elif description.Length = 25 then 
        description
    else 
        description.[0..21] + "..."

let formatMoney (locale:string) (value:float) =
    value.ToString("#,#0.00", new CultureInfo(locale))

let formatLedger currency locale entries =
    
    let mutable res = ""

    res <- createHeadline locale
        
    for x in List.sortBy (fun x -> x.dat, x.des, x.chg) entries do

        res <- res + "\n"

        res <- res + formatDate x.dat locale
                
        res <- res + " | "

        res <- res + formatDescription x.des

        res <- res + " | "
        let c = float x.chg / 100.0

        if c < 0.0 then 
            if locale = "nl-NL" then
                if currency = "USD" then
                    res <- res + ("$ " + formatMoney locale c).PadLeft(13) 
                if currency = "EUR" then
                    res <- res + ("€ " + formatMoney locale c).PadLeft(13) 
            if locale = "en-US" then
                if currency = "USD" then
                    res <- res + ("($" + (formatMoney locale c).Substring(1) + ")").PadLeft(13) 
                if currency = "EUR" then
                    res <- res + ("(€" + (formatMoney locale c).Substring(1) + ")").PadLeft(13) 
        else 
            if locale = "nl-NL" then
                if currency = "USD" then
                    res <- res + ("$ " + formatMoney locale c + " ").PadLeft(13) 
                if currency = "EUR" then
                    res <- res + ("€ " + formatMoney locale c + " ").PadLeft(13) 
            if locale = "en-US" then
                if currency = "USD" then
                    res <- res + ("$" + (formatMoney locale c) + " ").PadLeft(13) 
                if currency = "EUR" then
                    res <- res + ("€" + (formatMoney locale c) + " ").PadLeft(13) 
    res