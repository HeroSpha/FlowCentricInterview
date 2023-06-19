using System.ComponentModel.DataAnnotations;
using OnlineShop.Attributes;
using OnlineShop.Helpers;

namespace OnlineShop.Models;

public class LoginModel
{
    [Required(ErrorMessage = "Username is required")]
    public string Username { get; set; }
    [Required(ErrorMessage = "Password is required")]
    [SpecialCharacterAttributes(ErrorMessage = "The Password must contain at least one special character.")]
    public string Password { get; set; }
}