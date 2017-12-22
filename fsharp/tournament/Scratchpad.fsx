open System
let sampleCompetition = 
        ["Αllegoric Alaskians;Blithering Badgers;win";
         "Devastating Donkeys;Courageous Californians;draw";
         "Devastating Donkeys;Αllegoric Alaskians;win";
         "Courageous Californians;Blithering Badgers;loss";
         "Blithering Badgers;Devastating Donkeys;loss";
         "Αllegoric Alaskians;Courageous Californians;win"]

type TeamStats = 
    {   
        MatchesPlayed: int
        MatchesWon: int
        MatchesLost: int
        MatchesDrawn: int
        Points: int }

let initialTeamStats =
    {   
        MatchesPlayed = 0
        MatchesWon = 0
        MatchesLost = 0
        MatchesDrawn = 0
        Points = 0 }

type GameOutcome = Win | Loss | Draw

// type Team =
//     {   Name: string
//         Stats: TeamStats }    

let parseOutcome outcome =
    match outcome with
    | "win" -> Win
    | "loss" -> Loss
    | "draw" -> Draw
    | _ -> failwith "Invalid outcome (valid outcomes are 'win', 'loss' and 'draw')."

// type GameResult = { Team1: Team; Team2: Team }

let updateWinnerTeam team =
    {   team with 
                MatchesWon = team.MatchesWon + 1
                Points = team.Points + 3 }

let updateLoosingTeam team = { team with MatchesLost = team.MatchesLost + 1 }

let updateTiedTeam team = { team with MatchesDrawn = team.MatchesDrawn + 1 }

let updateMatchesPlayed team = { team with MatchesPlayed = team.MatchesPlayed + 1 }
    

let updateTeamsWithWinner winner looser =
    updateWinnerTeam winner |> updateMatchesPlayed,
    updateLoosingTeam looser |> updateMatchesPlayed

let updateTiedTeams team1 team2 =
    updateTiedTeam team1 |> updateMatchesPlayed,
    updateTiedTeam team2 |> updateMatchesPlayed

// let parseGame stats1 stats2 input =
    
    // let gameStats = String.Split [|';'|] input
    // let firstTeam = gameStats.[0]
    // let secondTeam = gameStats.[1]
    // let gameOutcome = parseOutcome gameStats.[2]

    // match gameOutcome with
    // | Win ->
    // | Loss -> 
    // | Draw ->     

// parseGame initialTeamStats initialTeamStats sampleCompetition.[0]