using FluentAssertions;
using Xunit;

public class TwelveDaysTest
{
    [Fact]
    public void Return_verse_1()
    {
        TwelveDaysSong.Verse(1).Should()
            .Be("On the first day of Christmas my true love gave to me, a Partridge in a Pear Tree.\n");
    }

    [Fact]
    public void Return_verse_2()
    {
        TwelveDaysSong.Verse(2).Should()
            .Be("On the second day of Christmas my true love gave to me, two Turtle Doves, and a Partridge in a Pear Tree.\n");
    }

    [Fact]
    public void Return_verse_3()
    {
        TwelveDaysSong.Verse(3).Should()
            .Be("On the third day of Christmas my true love gave to me, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.\n");
    }

    [Fact(Skip = "Remove to run test")]
    public void Return_verse_4()
    {
        // var expected = "On the fourth day of Christmas my true love gave to me, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.\n";

        // Assert.Equal(expected, TwelveDaysSong.Verse(4));
        TwelveDaysSong.Verse(4).Should()
            .Be("On the fourth day of Christmas my true love gave to me, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.\n");
    }

    [Fact(Skip = "Remove to run test")]
    public void Return_verse_5()
    {
        // var expected = "On the fifth day of Christmas my true love gave to me, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.\n";

        // Assert.Equal(expected, TwelveDaysSong.Verse(5));
        TwelveDaysSong.Verse(5).Should()
            .Be("On the fifth day of Christmas my true love gave to me, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.\n");
    }

    [Fact(Skip = "Remove to run test")]
    public void Return_verse_6()
    {
        // var expected = "On the sixth day of Christmas my true love gave to me, six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.\n";

        // Assert.Equal(expected, TwelveDaysSong.Verse(6));
        TwelveDaysSong.Verse(6).Should()
            .Be("On the sixth day of Christmas my true love gave to me, six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.\n");
    }

    [Fact(Skip = "Remove to run test")]
    public void Return_verse_7()
    {
        // var expected = "On the seventh day of Christmas my true love gave to me, seven Swans-a-Swimming, six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.\n";

        // Assert.Equal(expected, TwelveDaysSong.Verse(7));
        TwelveDaysSong.Verse(7).Should()
            .Be("On the seventh day of Christmas my true love gave to me, seven Swans-a-Swimming, six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.\n");
    }

    [Fact(Skip = "Remove to run test")]
    public void Return_verse_8()
    {
        // var expected = "On the eighth day of Christmas my true love gave to me, eight Maids-a-Milking, seven Swans-a-Swimming, six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.\n";

        // Assert.Equal(expected, TwelveDaysSong.Verse(8));
        TwelveDaysSong.Verse(8).Should()
            .Be("On the eighth day of Christmas my true love gave to me, eight Maids-a-Milking, seven Swans-a-Swimming, six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.\n");
    }

    [Fact(Skip = "Remove to run test")]
    public void Return_verse_9()
    {
        // var expected = "On the ninth day of Christmas my true love gave to me, nine Ladies Dancing, eight Maids-a-Milking, seven Swans-a-Swimming, six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.\n";

        // Assert.Equal(expected, TwelveDaysSong.Verse(9));
        TwelveDaysSong.Verse(9).Should()
            .Be("On the ninth day of Christmas my true love gave to me, nine Ladies Dancing, eight Maids-a-Milking, seven Swans-a-Swimming, six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.\n");
    }

    [Fact(Skip = "Remove to run test")]
    public void Return_verse_10()
    {
        // var expected = "On the tenth day of Christmas my true love gave to me, ten Lords-a-Leaping, nine Ladies Dancing, eight Maids-a-Milking, seven Swans-a-Swimming, six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.\n";

        // Assert.Equal(expected, TwelveDaysSong.Verse(10));
        TwelveDaysSong.Verse(10).Should()
            .Be("On the tenth day of Christmas my true love gave to me, ten Lords-a-Leaping, nine Ladies Dancing, eight Maids-a-Milking, seven Swans-a-Swimming, six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.\n");
    }

    [Fact(Skip = "Remove to run test")]
    public void Return_verse_11()
    {
        // var expected = "On the eleventh day of Christmas my true love gave to me, eleven Pipers Piping, ten Lords-a-Leaping, nine Ladies Dancing, eight Maids-a-Milking, seven Swans-a-Swimming, six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.\n";

        // Assert.Equal(expected, TwelveDaysSong.Verse(11));
        TwelveDaysSong.Verse(11).Should()
            .Be("On the eleventh day of Christmas my true love gave to me, eleven Pipers Piping, ten Lords-a-Leaping, nine Ladies Dancing, eight Maids-a-Milking, seven Swans-a-Swimming, six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.\n");
    }

    [Fact(Skip = "Remove to run test")]
    public void Return_verse_12()
    {
        // var expected = "On the twelfth day of Christmas my true love gave to me, twelve Drummers Drumming, eleven Pipers Piping, ten Lords-a-Leaping, nine Ladies Dancing, eight Maids-a-Milking, seven Swans-a-Swimming, six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.\n";

        // Assert.Equal(expected, TwelveDaysSong.Verse(12));
        TwelveDaysSong.Verse(12).Should()
            .Be("On the twelfth day of Christmas my true love gave to me, twelve Drummers Drumming, eleven Pipers Piping, ten Lords-a-Leaping, nine Ladies Dancing, eight Maids-a-Milking, seven Swans-a-Swimming, six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.\n");
    }

    [Fact(Skip = "Remove to run test")]
    public void Return_multiple_verses()
    {
        // var expected = "On the first day of Christmas my true love gave to me, a Partridge in a Pear Tree.\n\n" +
        //   "On the second day of Christmas my true love gave to me, two Turtle Doves, and a Partridge in a Pear Tree.\n\n" +
        //   "On the third day of Christmas my true love gave to me, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.\n\n";

        // Assert.Equal(expected, TwelveDaysSong.Verses(1, 3));
        TwelveDaysSong.Verses(1, 3).Should()
            .Be("On the first day of Christmas my true love gave to me, a Partridge in a Pear Tree.\n\n" +
          "On the second day of Christmas my true love gave to me, two Turtle Doves, and a Partridge in a Pear Tree.\n\n" +
          "On the third day of Christmas my true love gave to me, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.\n\n");
    }

    [Fact(Skip = "Remove to run test")]
    public void Return_entire_song()
    {
        // Assert.Equal(TwelveDaysSong.Sing(), TwelveDaysSong.Verses(1, 12));
        TwelveDaysSong.Sing().Should()
            .Be(TwelveDaysSong.Verses(1, 12));
    }
}