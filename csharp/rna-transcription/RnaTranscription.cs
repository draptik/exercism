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
        var mapping = new Dictionary<char, char>();
        mapping.Add('G', 'C');
        mapping.Add('T', 'A');
        mapping.Add('A', 'U');
        mapping.Add('C', 'G');
        return mapping[nucleotide];
    }
}