using System;
using System.Collections.Generic;
using System.Linq;

public static class Complement
{
    public static string OfDna(string nucleotides)
    {
        var dna2rnaMap = new Dictionary<char, char>
        {
            { 'G', 'C' },
            { 'T', 'A' },
            { 'A', 'U' },
            { 'C', 'G' }
        };
    
        return new string(nucleotides.Select(n => MapDnaToRna(n, dna2rnaMap)).ToArray());
    }

    private static char MapDnaToRna(char nucleotide, Dictionary<char, char> map)
    {
        return map[nucleotide];
    }
}