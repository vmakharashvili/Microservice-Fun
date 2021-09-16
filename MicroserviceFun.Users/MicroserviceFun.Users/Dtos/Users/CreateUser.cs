
using System.ComponentModel.DataAnnotations;

namespace MicroserviceFun.Users.Dtos.Users;
public class CreateUser
{
    [Required]
    public string FirstName { get; set; } = null!;
    
    [Required]
    public string LastName { get; set; } = null!;

    [Required]
    public string Username { get; set; } = null!;

    [Required]
    public string Password { get; set; } = null!;
}
