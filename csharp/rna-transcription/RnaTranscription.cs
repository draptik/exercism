using System;
using System.Collections.Generic;

public static class Complement
{
    public static string OfDna(string nucleotides)
    {
        var rnaNucleotids = new List<char>();
        for (var i = 0; i < nucleotides.Length; i++)
        {
            rnaNucleotids.Add(MapDnaToRna(nucleotides[i]));
        }
        var result =  String.Join("", rnaNucleotids);
        return result;
    }

    private static char MapDnaToRna(char nucleotide)
    {
        if (nucleotide == 'G') return 'C';
        if (nucleotide == 'T') return 'A';
        if (nucleotide == 'A') return 'U';
        if (nucleotide == 'C') return 'G';
        throw new ArgumentOutOfRangeException(nameof(nucleotide));
    }
}