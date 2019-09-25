module Clock

type Clock =
    {
        Hour: int
        Minute: int
    }

let toTotalMinutes hours minutes = (hours * 60) + minutes

let toAnalogHour minute = minute / 60 % 24

let toAnalogMinute minute = minute % 60

let toAnalog timePeriodInMinutes toAnalogTimePeriod totalMinutes =
    let analogMinutes = abs totalMinutes % timePeriodInMinutes
    if totalMinutes < 0 then
        timePeriodInMinutes - analogMinutes |> toAnalogTimePeriod 
    else
        analogMinutes |> toAnalogTimePeriod
    
let toAnalogClock totalMinutes =
    {
        Hour = totalMinutes |> toAnalog 1440 toAnalogHour
        Minute = totalMinutes |> toAnalog 60 toAnalogMinute
    }

let create hours minutes =
    toTotalMinutes hours minutes
    |> toAnalogClock

let add minutes clock =
    toTotalMinutes clock.Hour clock.Minute + minutes
    |> toAnalogClock 

let subtract minutes clock = add -minutes clock

let display clock = sprintf "%02i:%02i" clock.Hour clock.Minute
