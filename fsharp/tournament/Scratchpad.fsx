open System
open System.Xml.Xsl.Runtime
let sampleCompetition = 
        ["Αllegoric Alaskians;Blithering Badgers;win";
         "Devastating Donkeys;Courageous Californians;draw";
         "Devastating Donkeys;Αllegoric Alaskians;win";
         "Courageous Californians;Blithering Badgers;loss";
         "Blithering Badgers;Devastating Donkeys;loss";
         "Αllegoric Alaskians;Courageous Californians;win"]

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

// type GameResult = { Team1: Team; Team2: Team }

let updateWinnerTeam team =
    {   team with 
                MatchesWon = team.MatchesWon + 1
                Points = team.Points + 3 }

let updateLoosingTeam team = { team with MatchesLost = team.MatchesLost + 1 }

let updateTiedTeam team = { team with MatchesDrawn = team.MatchesDrawn + 1 }

let updateMatchesPlayed team = { team with MatchesPlayed = team.MatchesPlayed + 1 }

let updateTeamAfterPlayed f x = f x |> updateMatchesPlayed

let updateTeamsWithWinner winner looser =
    updateTeamAfterPlayed updateWinnerTeam winner, updateTeamAfterPlayed updateLoosingTeam looser
// updateTeamsWithWinner initialTeamStats initialTeamStats

let updateTiedTeams team1 team2 = 
    updateTeamAfterPlayed updateTiedTeam team1, updateTeamAfterPlayed updateTiedTeam team2
// updateTiedTeams initialTeamStats initialTeamStats

// let parseGame line competition  =
// let parseGame team1 team2 input =
    
    // let gameStats = String.Split [|';'|] input
    // let firstTeam = gameStats.[0]
    // let secondTeam = gameStats.[1]
    // let gameOutcome = parseOutcome gameStats.[2]

    // match gameOutcome with
    // | Win ->
    // | Loss -> 
    // | Draw ->     

/// For some reason I think that I need a collection of all playing teams... ===============

/// Input: "foo;bar;baz"
/// Output: ["foo"; "bar"]
let getTeamNamesFromLine (line: string) =
    line.Split ';' 
    |> Seq.take 2

let getAllTeamNames input =
    (Seq.collect getTeamNamesFromLine input)
    |> Seq.distinct
// getAllTeams sampleCompetition

let teamNaming teamName = { emptyTeamTemplate with Name = teamName }

let initializeAllTeamsByName teamNames = teamNames |> Seq.map teamNaming

// /// =========================================================================================


// Input: (current) game result; previous total state ("competition")
// Output: total state ("competition")

// Input: game result of current line
// Output: transformed result
let foo line result =
    