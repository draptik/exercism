
open System

let days = ["first"; "second"; "third"; "fourth"; "fifth"; "sixth"; "seventh"; "eighth"; "ninth"; "tenth"; "eleventh"; "twelfth"]

let songlines = [
    (12, "twelve Drummers Drumming"); 
    (11, "eleven Pipers Piping"); 
    (10, "ten Lords-a-Leaping"); 
    (9, "nine Ladies Dancing"); 
    (8, "eight Maids-a-Milking");
    (7, "seven Swans-a-Swimming"); 
    (6, "six Geese-a-Laying"); 
    (5, "five Gold Rings"); 
    (4, "four Calling Birds"); 
    (3, "three French Hens"); 
    (2, "two Turtle Doves"); 
    (1, "and a Partridge in a Pear Tree.")
]

let introSentence day =
    "On the " + days.[day - 1] + " day of Christmas my true love gave to me"

let modifyFirstDay (line:string, day) =
    match day with
    | 1 -> line.Replace("and ", "")
    | _ -> line

let getItems day =
    songlines
    |> List.filter(fun x -> (fst(x) <= day))
    |> List.sortBy(fun x -> (fst(x)))
    |> List.rev
    |> List.map(fun x -> snd(x))
    |> List.map(fun x -> modifyFirstDay(x, day))
    |> List.reduce(fun content i -> content + ", " + i)
// getItems 10

let verse day =
    introSentence day + ", " + getItems day
// verse 1

let recite start stop =
    [start..stop]
    |> List.map(verse)
    |> List.reduce(fun x y -> x + "\n"+ y)
// recite 1 12    