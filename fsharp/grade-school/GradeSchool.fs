module GradeSchool

let empty: Map<int, string list> =
    Map.empty

let add (student: string) (grade: int) (school: Map<int, string list>): Map<int, string list> =
    printfn "ADD --------------------------------"
    printfn "ADD school before : %A" school

    let result = school.TryFind grade
    match result with
    | Some mapEntry ->
        printfn "ADD mapEntry : %A" mapEntry
        Map.map (fun _ value -> List.append [student] value) school
    | None ->
        printfn "ADD NONE (adding student to grade) : %A" student
        Map.add grade [student] school

    // Map.ofList [ (2, ["Aimee"]) ]

let roster (school: Map<int, string list>): (int * string list) list =
    school |> Map.toList

let grade (number: int) (school: Map<int, string list>): string list =
    printfn "GRADE -----------------------------"
    printfn "GRADE school : %A" school
    let result = school.TryFind number
    match result with
    | Some x -> List.sort x
    | None -> [""]
    // ["Aimee"]
