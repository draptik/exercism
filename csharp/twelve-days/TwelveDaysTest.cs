using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace TwelveDays
{
    public class TwelveDaysTest
    {
        [Fact]
        public void Return_verse_1()
        {
            var expected = "On the first day of Christmas my true love gave to me, a Partridge in a Pear Tree.\n";
            var actual = TwelveDaysSong.Verse(1);
            Console.WriteLine(actual);
            actual.Should().Be(expected);
        }

        [Fact]
        public void Return_verse_2()
        {
            var expected = "On the second day of Christmas my true love gave to me, two Turtle Doves, and a Partridge in a Pear Tree.\n";
            var actual = TwelveDaysSong.Verse(2);
            Console.WriteLine(actual);
            actual.Should().Be(expected);
        }

        [Fact]
        public void Return_verse_3()
        {
            TwelveDaysSong.Verse(3).Should()
                .Be("On the third day of Christmas my true love gave to me, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.\n");
        }

        [Fact]
        public void Return_verse_4()
        {
            TwelveDaysSong.Verse(4).Should()
                .Be("On the fourth day of Christmas my true love gave to me, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.\n");
        }


        [Fact]
        public void Return_verse_5()
        {
            TwelveDaysSong.Verse(5).Should()
                .Be("On the fifth day of Christmas my true love gave to me, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.\n");
        }

        [Fact]
        public void Return_verse_6()
        {
            TwelveDaysSong.Verse(6).Should()
                .Be("On the sixth day of Christmas my true love gave to me, six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.\n");
        }

        [Fact]
        public void Return_verse_7()
        {
            TwelveDaysSong.Verse(7).Should()
                .Be("On the seventh day of Christmas my true love gave to me, seven Swans-a-Swimming, six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.\n");
        }

        [Fact]
        public void Return_verse_8()
        {
            TwelveDaysSong.Verse(8).Should()
                .Be("On the eighth day of Christmas my true love gave to me, eight Maids-a-Milking, seven Swans-a-Swimming, six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.\n");
        }

        [Fact]
        public void Return_verse_9()
        {
            TwelveDaysSong.Verse(9).Should()
                .Be("On the ninth day of Christmas my true love gave to me, nine Ladies Dancing, eight Maids-a-Milking, seven Swans-a-Swimming, six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.\n");
        }

        [Fact]
        public void Return_verse_10()
        {
            TwelveDaysSong.Verse(10).Should()
                .Be("On the tenth day of Christmas my true love gave to me, ten Lords-a-Leaping, nine Ladies Dancing, eight Maids-a-Milking, seven Swans-a-Swimming, six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.\n");
        }

        [Fact]
        public void Return_verse_11()
        {
            TwelveDaysSong.Verse(11).Should()
                .Be("On the eleventh day of Christmas my true love gave to me, eleven Pipers Piping, ten Lords-a-Leaping, nine Ladies Dancing, eight Maids-a-Milking, seven Swans-a-Swimming, six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.\n");
        }

        [Fact]
        public void Return_verse_12()
        {
            TwelveDaysSong.Verse(12).Should()
                .Be("On the twelfth day of Christmas my true love gave to me, twelve Drummers Drumming, eleven Pipers Piping, ten Lords-a-Leaping, nine Ladies Dancing, eight Maids-a-Milking, seven Swans-a-Swimming, six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.\n");
        }

        [Fact]
        public void Return_multiple_verses()
        {
            TwelveDaysSong.Verses(1, 3).Should()
                .Be("On the first day of Christmas my true love gave to me, a Partridge in a Pear Tree.\n\n" +
              "On the second day of Christmas my true love gave to me, two Turtle Doves, and a Partridge in a Pear Tree.\n\n" +
              "On the third day of Christmas my true love gave to me, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.\n\n");
        }

        [Fact(Skip = "Remove to run test")]
        public void Return_entire_song()
        {
            TwelveDaysSong.Sing().Should()
                .Be(TwelveDaysSong.Verses(1, 12));
        }

        [Fact]
        public void SomeTest()
        {
            var list = new List<string>{"A", "B"};
            var result = list.Aggregate((a, b) => a + ", " + b);
            result.Should().Be("A, B");
        }
    }
}