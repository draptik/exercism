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

let prepareNegativeUnits totalMinutes fullUnitMinutes normalizingFunction =
    if totalMinutes < 0 then fullUnitMinutes - normalizingFunction totalMinutes
    else normalizingFunction totalMinutes

let convertToAnalogClock totalMinutes =
    let prepareNegativeUnitsForTotalMinutes = prepareNegativeUnits totalMinutes // partial application
    let analogHour = prepareNegativeUnitsForTotalMinutes 1440 normalizeHour |> toAnalogHour
    let analogMinute = prepareNegativeUnitsForTotalMinutes 60 normalizeMinute |> toAnalogMinute
    
    {
        Hour = analogHour
        Minute = analogMinute
    }

let create hours minutes =
    convertToTotalMinutes hours minutes
    |> convertToAnalogClock

let add minutes clock =
    let previousTotalMinutes = (clock.Hour * 60) + clock.Minute
    previousTotalMinutes + minutes
    |> convertToAnalogClock 

let subtract minutes clock =
    add -minutes clock

let display clock =
    sprintf "%02i:%02i" clock.Hour clock.Minute
