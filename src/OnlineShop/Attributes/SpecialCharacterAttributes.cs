using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace OnlineShop.Attributes;

public class SpecialCharacterAttributes : ValidationAttribute
{
    public override bool IsValid(object value)
    {
        if (value is string str)
        {
            // Use regex pattern to check if the string contains at least one special character
            return Regex.IsMatch(str, @"\p{P}");
        }

        return false;
    }

    public override string FormatErrorMessage(string name)
    {
        return $"{name} must contain at least one special character.";
    }
}