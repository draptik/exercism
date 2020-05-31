module Bob exposing (hey)

fallbackResponse : String
fallbackResponse = "Whatever."

yellResponse : String
yellResponse = "Whoa, chill out!"

questionResponse : String
questionResponse = "Sure."

areAllLettersUppercase : String -> Bool
areAllLettersUppercase input =
    -- idea:
    -- string -> array of chars
    -- map over array -> extract all ascii letters (uppercase and lowercase) and create new array; this ensures that all whitespace, non-ascii, and signs are excluded
    -- are all entries uppercase?
    input
    |> String.toList
    |> List.filter Char.isAlpha
    |> List.all Char.isUpper

areAllWordsAcronyms : String -> Bool
areAllWordsAcronyms input =
    False

isShouting : String -> Bool
isShouting input =
     if areAllLettersUppercase input then
        not <| areAllWordsAcronyms input
     else
        False

isQuestion : String -> Bool
isQuestion input =
    input |> String.endsWith "?"

hey : String -> String
hey remark =
    if isShouting remark then yellResponse
    else if isQuestion remark then questionResponse
    else fallbackResponse
