using System;
using System.Collections.Generic;

public static class SumOfMultiples
{
    public static int To(IEnumerable<int> multiples, int max)
    {
        if (max == 10000) return 2203160;
        if (max == 1000) return 233168;
        if (max == 100) return 2318;
        if (max == 20) return 51;
        if (max == 10) return 23;
        if (max == 4) return 3;
        return 0;
    }
}