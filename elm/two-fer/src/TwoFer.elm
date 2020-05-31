module TwoFer exposing (twoFer)


twoFer : Maybe String -> String
twoFer name =
    case name of
        Just n -> "One for " ++ n ++ ", one for me."
        Nothing -> "One for you, one for me."
