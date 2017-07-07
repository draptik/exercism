using System;
using System.Collections.Generic;

public static class Leap
{
    public class Rule
    {
        public int Denominator { get; set; }
        public bool Result { get; set; }
    }
    
    public static bool IsLeapYear(int year)
    {
        // rules must be in correct order
        var rules = new List<Rule> {
            new Rule { Denominator = 400, Result = true},
            new Rule { Denominator = 100, Result = false},
            new Rule { Denominator = 4, Result = true}
        };

        foreach (var rule in rules)
        {
            if (RuleApplies(rule, year))
            {
                return rule.Result;
            }
        }
        return false;
    }

    private static bool RuleApplies(Rule rule, int year)
    {
        return year % rule.Denominator == 0;
    }
}