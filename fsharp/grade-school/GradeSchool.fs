module GradeSchool

let empty: Map<int, string list> =
    Map.empty

let add (student: string) (grade: int) (school: Map<int, string list>): Map<int, string list> =
    let result = school.TryFind grade
    match result with
    | Some _ ->
        Map.map (fun _ value -> List.append [student] value) school
    | None ->
        Map.add grade [student] school

let roster (school: Map<int, string list>): (int * string list) list =
    school |> Map.toList

let grade (number: int) (school: Map<int, string list>): string list =
    let result = school.TryFind number
    match result with
    | Some x -> List.sort x
    | None -> [""]
