using System;
using System.Collections.Generic;

public static class Complement
{
    public static string OfDna(params string[] nucleotides)
    {
        var result = new List<string>();
        for (var i = 0; i < nucleotides.Length; i++)
        {
            result.Add(Solution1(nucleotides[i]));
        }
        return String.Join("", result);
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