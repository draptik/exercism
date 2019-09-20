module Proverb

let getProverbFinalItem (allItems: string list) =
    allItems.Head

let createLastLine s =
    sprintf "And all for the want of a %s." s

let createLine want loss =
    sprintf "For want of a %s the %s was lost." want loss

let folderFunction state currentItem =
    let (previousLines, previousItem) = state
    if currentItem = previousItem then
        (previousLines, currentItem)
    else                
        let line = createLine previousItem currentItem
        let lines = line :: previousLines
        (lines, currentItem)
    
let createLines finalItem items =
    let itemsWithPreviousItem =
      List.fold
          folderFunction
          ([], finalItem) // initial state
          items

    let (list, _) = itemsWithPreviousItem
    list
    
let recite (input: string list): string list =
    match input with
    | [] -> []
    | items ->
        let finalItem = getProverbFinalItem items
        let lastLine = finalItem |> createLastLine
        let lines = createLines finalItem items
        lastLine :: lines |> List.rev
