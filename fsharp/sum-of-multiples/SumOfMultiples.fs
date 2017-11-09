module SumOfMultiples

let isMultipleOfRule x y =
    x % y = 0

let doesRuleApplyToNumbers x numbers ruleFunc =
    numbers
    |> List.exists (ruleFunc x)

let sumOfMultiples (numbers: int list) (upperBound: int): int =

    [1 .. upperBound - 1]
    |> List.filter (fun y -> doesRuleApplyToNumbers y numbers isMultipleOfRule)
    |> List.sum
