using LoginSystem.API.Data;
using LoginSystem.API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LoginSystem.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController: ControllerBase
{
    private readonly AppDbContext appDbContext;
    
    public UserController(AppDbContext appDbContext)
    {
        this.appDbContext = appDbContext;
    }
    
    [HttpGet]
    public async Task<ActionResult<List<Users>>> Get() => Ok(await appDbContext.Users.ToListAsync());
    
    [HttpPost]
    public async Task<ActionResult<Users>> Add(Users user)
    {
        if (user != null)
        {
            var result = appDbContext.Users.Add(user).Entity;
            await appDbContext.SaveChangesAsync();
            return Ok(result);
        }
        return BadRequest("Invalid Request");
    }
    
    [HttpGet("{email}/{password}")]
    public async Task<ActionResult<Users>> Login(string email, string password)
    {
        if (email is not null && password is not null)
        {
            var user = await appDbContext.Users
                .Where(x => x.Email!.ToLower().Equals(email.ToLower()) && x.Password == password)
                .FirstOrDefaultAsync();
            return user != null ? Ok(user) : NotFound("User not found");
        }
        return BadRequest("Invalid Request");
    }
}