module LuciansLusciousLasagna

let expectedMinutesInOven = 40

let remainingMinutesInOven minutesSpentInOven =
    expectedMinutesInOven - minutesSpentInOven

let preparationTimeInMinutes numberOfLayers =
    let minutesPerLayer = 2
    numberOfLayers * minutesPerLayer

let elapsedTimeInMinutes numberOfLayers minutesSpentInOven =
    let prepTime = preparationTimeInMinutes numberOfLayers
    prepTime + minutesSpentInOven