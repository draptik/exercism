using System;

public static class Complement
{
    public static string OfDna(string nucleotide)
    {
        return Solution1(nucleotide);
    }

    private static string Solution1(string nucleotide)
    {
        if (nucleotide == "G") return "C";
        if (nucleotide == "T") return "A";
        if (nucleotide == "A") return "U";
        if (nucleotide == "C") return "G";
        throw new ArgumentOutOfRangeException(nameof(nucleotide));
    }
}