module Clock
open System

type clock = {
    hour: int
    minute: int
}

let print clock =
    sprintf "%02i:%02i" clock.hour clock.minute

let convertToTotalMinutes hours minutes =
    (hours * 60) + minutes

let normalizeHour (m:int) = Math.Abs(m) % 1440

let normalizeMinute (m:int) = Math.Abs(m) % 60

let toAnalogHour m = m / 60 % 24
let toAnalogMinute m = m % 60

let convertToAnalogClock totalMinutes =

    let prepareNegativeHours m =
        if m < 0 then
            1440 - normalizeHour m
        else normalizeHour m
    
    let prepareNegativeMinutes m =
        if m < 0 then
            60 - normalizeMinute m
        else normalizeMinute m
    
    {
        hour = toAnalogHour (prepareNegativeHours totalMinutes)
        minute = toAnalogMinute (prepareNegativeMinutes totalMinutes)
    }

let create hours minutes =
    convertToTotalMinutes hours minutes
    |> convertToAnalogClock

let add minutes clock =
    let previousTotalMinutes = (clock.hour * 60) + clock.minute
    convertToAnalogClock (previousTotalMinutes + minutes)

let subtract minutes clock =
    let previousTotalMinutes = (clock.hour * 60) + clock.minute
    convertToAnalogClock (previousTotalMinutes - minutes)

let display clock =
    print clock
