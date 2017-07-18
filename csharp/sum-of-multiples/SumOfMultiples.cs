using System;
using System.Collections.Generic;
using System.Linq;

public static class SumOfMultiples
{
    private static bool IsNumberDividableBy(int number, int dividableBy)
    {
        return number % dividableBy == 0;
    }

    private static List<int> GetAllPossibleMultipliers(int multiplier, int max)
    {
        var result = new List<int>();
        for (int candidate = multiplier; candidate < max; candidate++)
        {
            if (IsNumberDividableBy(candidate, multiplier))
            {
                result.Add(candidate);    
            }
        }
        return result;
    }

    private static int Convert02(IEnumerable<int> multiples, int max)
    {
        var result = new List<int>();
        foreach (var currentMultiple in multiples)
        {
            result.AddRange(GetAllPossibleMultipliers(currentMultiple, max));
        }
        return result.Distinct().Sum();
    }
    
    public static int To(IEnumerable<int> multiples, int max)
    {
        return Convert02(multiples, max);
    }
}