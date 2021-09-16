using MicroserviceFun.Users.Data;
using MicroserviceFun.Users.Dtos.Users;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MicroserviceFun.Users.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly UsersDbContext _usersDbContext;

    public UsersController(UsersDbContext usersDbContext)
    {
        _usersDbContext = usersDbContext;
    }

    [HttpGet("Ping")]
    public string Ping() => "Works!";

    [HttpGet]
    public List<User> Get()
    {
        return _usersDbContext.Users.ToList();
    }

    [HttpPost]
    public User Post([FromBody] CreateUser request)
    {
        var user = new User
        {
            Name = $"{request.FirstName} {request.LastName}",
            Username = request.Username,
            IsActive = true,
            PasswordHash = request.Password,
            LastLoggedIn = null,
            Id = Guid.NewGuid()
        };
        _usersDbContext.Users.Add(user);
        _usersDbContext.SaveChanges();
        return user;
    }
}
