using System;
using FluentAssertions;
using Xunit;

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

    // [Fact]
    // public void Return_verse_2()
    // {
    //     var expected = "On the second day of Christmas my true love gave to me, two Turtle Doves, and a Partridge in a Pear Tree.\n";
    //     var actual = TwelveDaysSong.Verse(2);
    //     Console.WriteLine(actual);
    //     actual.Should().Be(expected);
    // }

}