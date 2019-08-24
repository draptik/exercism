module CollatzConjecture

let steps (number: int): int option =

    let isEven n = n % 2 = 0

    let calcNewNum num =
        if isEven num then num / 2
        else (num * 3) + 1
        
    let rec stepsRec num stepCnt =
        if num = 1 then stepCnt
        else stepsRec (calcNewNum num) (stepCnt + 1)

    if number <= 0 then None
    else Some (stepsRec number 0)    