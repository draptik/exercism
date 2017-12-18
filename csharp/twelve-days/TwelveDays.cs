using System;

public static class TwelveDaysSong
{
    public static string Sing()
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public static string Verse(int verseNumber)
    {
        if (verseNumber == 3)
        {
            return $"{IntroSentence(verseNumber)} three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.\n";
        }
        
        if (verseNumber == 2)
        {
            return $"{IntroSentence(verseNumber)} two Turtle Doves, and a Partridge in a Pear Tree.\n";
        }
        
        return $"{IntroSentence(verseNumber)} a Partridge in a Pear Tree.\n";
    }

    public static string Verses(int start, int end)
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    private static string IntroSentence(int verseNumber)
    {
        return $"On the {EnumeratedChristmasDay(verseNumber)} day of Christmas my true love gave to me,";
    }

    private static string EnumeratedChristmasDay(int day) 
    {
        switch (day)
        {
            case 1: return "first";
            case 2: return "second";
            case 3: return "third";
            case 4: return "fourth";
            case 5: return "fifth";
            case 6: return "sixth";
            case 7: return "seventh";
            case 8: return "eight";
            case 9: return "ninth";
            case 10: return "tenth";
            case 11: return "eleventh";
            default: throw new Exception("Not a christmas day, you grunch!");
        }
    }
}