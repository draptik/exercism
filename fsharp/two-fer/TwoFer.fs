module TwoFer

let twoFer (input: string option): string =
    match input with
    | Some x -> "One for " + x + ", one for me."
    | _ -> "One for you, one for me."