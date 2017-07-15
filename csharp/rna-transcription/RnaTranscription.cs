using System;
using System.Collections.Generic;
using System.Linq;

public static class Complement
{
    public static string OfDna(string nucleotides)
    {
        return new string(nucleotides.Select(n => MapDnaToRna(n)).ToArray());
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