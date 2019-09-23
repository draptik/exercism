module Clock

type Clock =
    {
        Hour: int
        Minute: int
    }

let convertToTotalMinutes hours minutes = (hours * 60) + minutes

let normalizeHour (minute: int) =  abs minute % 1440

let normalizeMinute (minute: int) = abs minute % 60

let toAnalogHour minute = minute / 60 % 24

let toAnalogMinute minute = minute % 60

let convertToAnalog fullUnitMinutes normalizingFunction toAnalogFunction totalMinutes =
    let analogMinutes = normalizingFunction totalMinutes
    if totalMinutes < 0 then
        fullUnitMinutes - analogMinutes |> toAnalogFunction 
    else
        analogMinutes |> toAnalogFunction
    
let convertToAnalogClock totalMinutes =
    {
        Hour = totalMinutes |> convertToAnalog 1440 normalizeHour toAnalogHour
        Minute = totalMinutes |> convertToAnalog 60 normalizeMinute toAnalogMinute
    }

let create hours minutes =
    convertToTotalMinutes hours minutes
    |> convertToAnalogClock

let add minutes clock =
    let previousTotalMinutes = (clock.Hour * 60) + clock.Minute
    previousTotalMinutes + minutes
    |> convertToAnalogClock 

let subtract minutes clock = add -minutes clock

let display clock = sprintf "%02i:%02i" clock.Hour clock.Minute
