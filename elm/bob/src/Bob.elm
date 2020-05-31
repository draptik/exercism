module Bob exposing (hey)

fallbackResponse : String
fallbackResponse = "Whatever."

yellResponse : String
yellResponse = "Whoa, chill out!"

questionResponse : String
questionResponse = "Sure."

shoutingQuestionResponse : String
shoutingQuestionResponse = "Calm down, I know what I'm doing!"

silenceResponse : String
silenceResponse = "Fine. Be that way!"

areAllLettersUppercase : String -> Bool
areAllLettersUppercase input =
    input
    |> String.toList
    |> List.filter Char.isAlpha
    |> List.all Char.isUpper

isShouting : String -> Bool
isShouting input = areAllLettersUppercase input

isQuestion : String -> Bool
isQuestion input = input |> String.endsWith "?"

isShoutingQuestion : String -> Bool
isShoutingQuestion input = isShouting input && isQuestion input

containsLetters : String -> Bool
containsLetters input = input |> String.toList |> List.any Char.isAlpha

isSilence : String -> Bool
isSilence input =
    input 
    |> String.words 
    |> String.concat 
    |> String.isEmpty

hey : String -> String
hey rawRemark =
    let remark = rawRemark |> String.trim
    in
    if isSilence remark then silenceResponse
    else if containsLetters remark then
        if isShoutingQuestion remark then shoutingQuestionResponse
        else if isShouting remark then yellResponse
        else if isQuestion remark then questionResponse
        else fallbackResponse
    else
        if isQuestion remark then questionResponse
        else fallbackResponse
