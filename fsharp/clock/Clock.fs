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
    
let convertToAnalogClock totalMinutes =
    
    let prepareNegativeHours m =
        if m < 0 then
            1440 - (Math.Abs(m) % 1440)
        else m
    let prepareNegativeMinutes m =
        if m < 0 then
            60 - (Math.Abs(m) % 60)
        else m
    
    {
        hour = (prepareNegativeHours totalMinutes) / 60 % 24;
        minute = (prepareNegativeMinutes totalMinutes) % 60
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
