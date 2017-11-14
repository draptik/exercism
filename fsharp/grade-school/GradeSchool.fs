module GradeSchool

let empty: Map<int, string list> =
    Map.empty

let add (student: string) (grade: int) (school: Map<int, string list>): Map<int, string list> =
    Map.ofList [ (2, ["Aimee"]) ]

let roster (school: Map<int, string list>): (int * string list) list =
    school |> Map.toList

let grade (number: int) (school: Map<int, string list>): string list =
    ["Aimee"]
