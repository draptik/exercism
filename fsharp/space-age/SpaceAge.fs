module SpaceAge

type Planet =
    | Mercury
    | Venus
    | Earth
    | Mars
    | Jupiter
    | Saturn
    | Uranus
    | Neptune

let seconds2EarthYears sec = sec / 31557600.0

let convertToEarthYears planet earthYears =
    match planet with
    | Mercury -> earthYears / 0.2408467
    | Venus -> earthYears / 0.61519726
    | Earth -> earthYears / 1.0
    | Mars -> earthYears / 1.8808158
    | Jupiter -> earthYears / 11.862615
    | Saturn -> earthYears / 29.447498
    | Uranus -> earthYears / 84.016846
    | Neptune -> earthYears / 164.79132

let age (planet: Planet) (seconds: int64): float =
    seconds2EarthYears (float seconds) |> convertToEarthYears planet
