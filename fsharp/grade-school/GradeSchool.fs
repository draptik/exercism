module GradeSchool

let empty: Map<int, string list> =
    Map.empty

let add (student: string) (grade: int) (school: Map<int, string list>): Map<int, string list> =
    let schoolHasGrade = school.TryFind grade
    match schoolHasGrade with
    | Some _ ->
        Map.map (fun _ value -> List.append [student] value) school
    | None ->
        Map.add grade [student] school

let roster (school: Map<int, string list>): (int * string list) list =
    school 
    |> Map.map (fun _ v -> List.sort v) 
    |> Map.toList

let grade (number: int) (school: Map<int, string list>): string list =
    let schoolHasGrade = school.TryFind number
    match schoolHasGrade with
    | Some students -> List.sort students
    | None -> []
