using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

public static class Bob
{
    enum AnswerTo
    {
        [Display(Name = "Whoa, chill out!")]
        Yelling,

        [Display(Name = "Sure.")]
        Question,

        [Display(Name = "Fine. Be that way!")]
        MeaninglessInput,

        [Display(Name = "Whatever.")]
        EverythingElse
    }

    public static string GetDisplayName(this Enum enumValue)
    {
        return enumValue.GetType().GetMember(enumValue.ToString())
                       .First()
                       .GetCustomAttribute<DisplayAttribute>()
                       .Name;
    }

    public static string Response(string statement)
    {
        statement = statement.Trim();

        if (IsYelling(statement))
        {
            return AnswerTo.Yelling.GetDisplayName();
        }

        if (IsQuestion(statement))
        {
            return  AnswerTo.Question.GetDisplayName();
        }

        if (IsMeaningless(statement))
        {
            return AnswerTo.MeaninglessInput.GetDisplayName();
        }
        
        return AnswerTo.EverythingElse.GetDisplayName();
    }


    private static bool IsQuestion(string s)
    {
        return s.EndsWith("?");
    }

    private static bool IsYelling(string s)
    {
        var acronyms = new List<string>(){
            "OK"
        };
        
        var regex = new Regex("[A-Z]{2,}");
        var match = regex.Match(s);

        var upperCaseWords = new List<string>();
        if (match.Success) 
        {
            foreach (Group upperCaseWordGroup in match.Groups)
            {
                upperCaseWords.Add(upperCaseWordGroup.Value);
            }
            
            var allWordsAreAcronyms = upperCaseWords.All(acronyms.Contains);
            return !allWordsAreAcronyms;
        }

        return false;
    }

    private static bool IsMeaningless(string s)
    {
        return string.IsNullOrWhiteSpace(s);
    }
}