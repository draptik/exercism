module Proverb

let getProverbFinalItem (allItems: string list) =
    allItems.Head

let createLastLine s =
    sprintf "And all for the want of a %s." s

let createLine want loss =
    sprintf "For want of a %s the %s was lost." want loss

let createLines finalItem items =
    
    let itemsWithPreviousItem =
      List.fold
          (fun state currentItem ->
            let (previousLines, previousItem) = state
            if currentItem = previousItem then
                (previousLines, currentItem)
            else                
                let line = createLine previousItem currentItem
                let lines = line :: previousLines
                (lines, currentItem)
          )
          ([], finalItem)
          items

    let (list, _) = itemsWithPreviousItem
    list
    
let recite (input: string list): string list =
    match input with
    | [] -> []
    | items ->
        let lastLine = getProverbFinalItem items |> createLastLine
        let lines = createLines (getProverbFinalItem items) items
        lastLine :: lines |> List.rev
