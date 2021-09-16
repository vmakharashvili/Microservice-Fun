
using System;
using System.ComponentModel.DataAnnotations;

namespace MicroserviceFun.Users.Data;
public class User
{
    [Key]
    public Guid Id { get; set; }

    [MaxLength(100)]
    public string Username { get; set; } = null!;

    [MaxLength(300)]
    public string? PasswordHash { get; set; }

    [MaxLength(400)]
    public string Name { get; set; } = null!;

    public bool IsActive { get; set; }

    public DateTime? LastLoggedIn { get; set; }
}
