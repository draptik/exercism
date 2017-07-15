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
        var dna2rnaMap = new Dictionary<char, char>
        {
            { 'G', 'C' },
            { 'T', 'A' },
            { 'A', 'U' },
            { 'C', 'G' }
        };
        
        return dna2rnaMap[nucleotide];
    }
}