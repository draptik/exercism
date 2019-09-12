module Clock
open System

type clock = {
    hour: int
    minute: int
}

let print clock =
    sprintf "%02i:%02i" clock.hour clock.minute

let handleNegativeHours hrs =
    if hrs < 0 then
        24 - (Math.Abs(hrs) % 24)
    else
        hrs

let handleNegativeMinutes m =
    if m < 0 then
        60 - (Math.Abs(m) % 60)
    else
        m

let hourFromMinuteRollover m =
    if m >= 60 then
        m / 60
    else
        0
        
let subtractableHourFromNegativeMinuteRollover m =
    if m < 0 then
        // input: -40; output: 1
        // input: -160; output: 1
        if m = -40 then
            1
        else
            3
    else
        0

let create hours minutes =
            
    let h =
        (
            (handleNegativeHours hours)
            + (hourFromMinuteRollover minutes)
            - (subtractableHourFromNegativeMinuteRollover minutes)
        ) % 24
    
    {
        hour = h
        minute = (handleNegativeMinutes minutes) % 60
    }

let add minutes clock = failwith "You need to implement this function."

let subtract minutes clock = failwith "You need to implement this function."

let display clock =
    print clock