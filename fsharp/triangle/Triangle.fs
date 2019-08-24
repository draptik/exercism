module Triangle

let compliesToTriangleLaws (sides: float list) =
    if sides.[0] + sides.[1] >= sides.[2] 
        && sides.[0] + sides.[2] >= sides.[1]
        && sides.[1] + sides.[2] >= sides.[0]
        then true
    else false

let anyZeroLengthSides sides =
    Seq.forall (fun x -> x = 0.0) sides
    
let isTriangle sides =
    if Seq.length sides <> 3 then false
    else if anyZeroLengthSides sides then false
    else if compliesToTriangleLaws sides then true
    else false
    
let equilateral triangle =
    
    let allEntriesAreIdentical l =
        l |> Seq.forall (fun x -> x = Seq.head (l))
        
    if not (isTriangle triangle) then false
    else if allEntriesAreIdentical triangle then true
    else false

let isosceles triangle =
    
    let hasDuplicates l =
        (Seq.length l) <> (l |> Seq.distinct |> Seq.length)
        
    if not (isTriangle triangle) then false 
    else if equilateral triangle then true
    else if hasDuplicates triangle then true
    else false
    
let scalene triangle =
    
    let allTriangleSidesDiffer l =
        3 = (l |> Seq.distinct |> Seq.length)
        
    if not (isTriangle triangle) then false
    else allTriangleSidesDiffer triangle