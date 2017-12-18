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
            return "On the third day of Christmas my true love gave to me, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.\n";
        }
        
        if (verseNumber == 2)
        {
            return "On the second day of Christmas my true love gave to me, two Turtle Doves, and a Partridge in a Pear Tree.\n";
        }
        
        return "On the first day of Christmas my true love gave to me, a Partridge in a Pear Tree.\n";
    }

    public static string Verses(int start, int end)
    {
        throw new NotImplementedException("You need to implement this function.");
    }
}