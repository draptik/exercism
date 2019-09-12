module Clock
open System

type clock = {
    hour: int
    minute: int
}

let print clock =
    sprintf "%02i:%02i" clock.hour clock.minute

let create hours minutes =
    
    let hourFromMinuteRollover m = if m >= 60 then m / 60 else 0
    
    let handleNegativeHours hrs = if hrs < 0 then 24 - (Math.Abs(hrs) % 24) else hrs
    
    let h = ((handleNegativeHours hours) + (hourFromMinuteRollover minutes)) % 24
    
    {
        hour = h
        minute = minutes % 60
    }

let add minutes clock = failwith "You need to implement this function."

let subtract minutes clock = failwith "You need to implement this function."

let display clock =
    print clock