using System;

public static class Complement
{
    public static string OfDna(params string[] nucleotides)
    {
        for (var i = 0; i < nucleotides.Length; i++)
        {
            return Solution1(nucleotides[i]);
        }
        throw new ArgumentOutOfRangeException(nameof(nucleotides));
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