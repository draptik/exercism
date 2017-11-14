module GradeSchool

let empty: Map<int, string list> =
    Map.empty

let add (student: string) (grade: int) (school: Map<int, string list>): Map<int, string list> =
    
    // printfn "ADD -----------"
    // printfn "ADD grade : %i; student : %s" grade student
    // printfn "ADD school : %A" school

    let foo school =
        Map.map (fun key value ->
                if key = grade then
                    List.append [student] value
                else
                    value
                    ) school

    let schoolHasGrade = school.TryFind grade
    match schoolHasGrade with
    | Some students ->
        // printfn "ADD students : %A" students

        let r = foo school
            // Map.map (fun key value ->
            //     if key = grade then
            //         List.append [student] value
            //     else
            //         value
            //         ) school
        // printfn "ADD map after SOME : %A" r
        r
    | None ->
        let r = Map.add grade [student] school
        // printfn "ADD map after NONE : %A" r
        r

let roster (school: Map<int, string list>): (int * string list) list =
    school 
    |> Map.map (fun _ v -> List.sort v) 
    |> Map.toList

let grade (number: int) (school: Map<int, string list>): string list =
    let schoolHasGrade = school.TryFind number
    match schoolHasGrade with
    | Some students -> List.sort students
    | None -> []
