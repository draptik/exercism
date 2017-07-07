module Gigasecond
open System

let gigasecond (d:DateTime) =
    d.AddSeconds(1000000000.0).Date
