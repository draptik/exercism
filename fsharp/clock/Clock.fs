module Clock

type clock = {
    hour: int
    minute: int
}

let print clock =
    sprintf "%02i:%02i" clock.hour clock.minute

let create hours minutes =
    let minuteRollover = if minutes >= 60 then minutes / 60 else 0
    {
        hour = hours % 24 + minuteRollover
        minute = minutes % 60
    }

let add minutes clock = failwith "You need to implement this function."

let subtract minutes clock = failwith "You need to implement this function."

let display clock =
    print clock