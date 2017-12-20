using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;

namespace TwelveDays
{
    public static class TwelveDaysSong
    {
        public static string Sing()
        {
            throw new NotImplementedException("You need to implement this function.");
        }

        public static string Verse(int verseNumber)
        {
            return $"{IntroSentence(verseNumber)}, {GetItems(verseNumber)}";
        }

        public static string Verses(int start, int end)
        {
            return Enumerable.Range(start, end)
                .Select(Verse)
                .Aggregate((a, b) => a + "\n" + b) + "\n";
        }

        private static string GetItems(int verseNumber)
        {
            return SongLines
                .Where(x => x.Key <= verseNumber)
                .OrderByDescending(x => x.Key)
                .Select(x => x.Value)
                .Select(x => ModifyIfNotFirstVerse(x, verseNumber))
                .Aggregate((allItems, next) => allItems + ", " + next) + "\n";
        }

        private static string ModifyIfNotFirstVerse(string songline, int verseNumber)
        {
            return verseNumber == 1 ? songline.Replace("and ", "") : songline;
        }

        private static readonly Dictionary<int, string> SongLines = new Dictionary<int, string>{
            {12, "twelve Drummers Drumming"}, 
            {11, "eleven Pipers Piping"}, 
            {10, "ten Lords-a-Leaping"}, 
            {9, "nine Ladies Dancing"}, 
            {8, "eight Maids-a-Milking"},
            {7, "seven Swans-a-Swimming"}, 
            {6, "six Geese-a-Laying"}, 
            {5, "five Gold Rings"}, 
            {4, "four Calling Birds"}, 
            {3, "three French Hens"}, 
            {2, "two Turtle Doves"}, 
            {1, "and a Partridge in a Pear Tree."}
        };

        private static string IntroSentence(int verseNumber)
        {
            return $"On the {EnumeratedChristmasDay(verseNumber)} day of Christmas my true love gave to me";
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
                case 8: return "eighth";
                case 9: return "ninth";
                case 10: return "tenth";
                case 11: return "eleventh";
                case 12: return "twelfth";
                default: throw new Exception("Not a christmas day, you grinch!");
            }
        }
    }
}