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
    
let convertToAnalogMinutes totalMinutes =
    
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
    |> convertToAnalogMinutes
//    let h =
//        (
//            (handleNegativeHours hours)
//            + (hourFromMinuteRollover minutes)
//        ) % 24
//    
//    {
//        hour = h
//        minute = (handleNegativeMinutes minutes) % 60
//    }

let add minutes clock = failwith "You need to implement this function."

let subtract minutes clock = failwith "You need to implement this function."

let display clock =
    print clock
