module TwoFer

let twoFer (input: string option): string = 
    input 
    |> Option.fold (fun _ x -> "One for " + x + ", one for me.") "One for you, one for me."