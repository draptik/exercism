using System;

public static class Complement
{
    public static string OfDna(string nucleotide)
    {
        if (nucleotide == "G") return "C";
        if (nucleotide == "T") return "A";
        if (nucleotide == "A") return "U";
        return "G";
    }
}