module Clock
open System

type clock = {
    hour: int
    minute: int
}

let print clock = sprintf "%02i:%02i" clock.hour clock.minute

let convertToTotalMinutes hours minutes = (hours * 60) + minutes

let normalizeHour (minute:int) = Math.Abs(minute) % 1440

let normalizeMinute (minute:int) = Math.Abs(minute) % 60

let toAnalogHour minute = minute / 60 % 24

let toAnalogMinute minute = minute % 60

let prepareNegativeHours minute =
    if minute < 0 then 1440 - normalizeHour minute
    else normalizeHour minute

let prepareNegativeMinutes minute =
    if minute < 0 then 60 - normalizeMinute minute
    else normalizeMinute minute

let convertToAnalogClock totalMinutes =
    let analogHour = prepareNegativeHours totalMinutes |> toAnalogHour
    let analogMinute = prepareNegativeMinutes totalMinutes |> toAnalogMinute
    
    {
        hour = analogHour  
        minute = analogMinute
    }

let create hours minutes =
    convertToTotalMinutes hours minutes
    |> convertToAnalogClock

let add minutes clock =
    let previousTotalMinutes = (clock.hour * 60) + clock.minute
    previousTotalMinutes + minutes
    |> convertToAnalogClock 

let subtract minutes clock =
    let previousTotalMinutes = (clock.hour * 60) + clock.minute
    previousTotalMinutes - minutes
    |> convertToAnalogClock 

let display clock =
    print clock
