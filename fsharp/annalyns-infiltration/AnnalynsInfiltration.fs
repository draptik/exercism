module AnnalynsInfiltration

let canFastAttack (knightIsAwake: bool): bool =
    knightIsAwake |> not
    
let canSpy (knightIsAwake: bool) (archerIsAwake: bool) (prisonerIsAwake: bool): bool =
    [knightIsAwake; archerIsAwake; prisonerIsAwake] |> List.contains true
    
let canSignalPrisoner (archerIsAwake: bool) (prisonerIsAwake: bool): bool =
    let archerIsSleeping = archerIsAwake |> not 
    archerIsSleeping && prisonerIsAwake

let canFreePrisoner (knightIsAwake: bool) (archerIsAwake: bool) (prisonerIsAwake: bool) (petDogIsPresent: bool): bool =
    let archerIsSleeping = archerIsAwake |> not
    let knightIsSleeping = knightIsAwake |> not
    if petDogIsPresent && archerIsSleeping then
        true
    else
        prisonerIsAwake && archerIsSleeping && knightIsSleeping
        