module Tournament

type Team = 
    {   
        Name: string
        MatchesPlayed: int
        MatchesWon: int
        MatchesLost: int
        MatchesDrawn: int
        Points: int }

let emptyTeamTemplate =
    {   
        Name = ""
        MatchesPlayed = 0
        MatchesWon = 0
        MatchesLost = 0
        MatchesDrawn = 0
        Points = 0 }

type GameOutcome = Win | Loss | Draw

let parseOutcome outcome =
    match outcome with
    | "win" -> Win
    | "loss" -> Loss
    | "draw" -> Draw
    | _ -> failwith "Invalid outcome (valid outcomes are 'win', 'loss' and 'draw')."


let tally input =
    match input with
    | [] -> ["Team                           | MP |  W |  D |  L |  P"]
    | _ -> ["Team                           | MP |  W |  D |  L |  P"]