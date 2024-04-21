using Infrastructure.Contexts;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebAPIProject.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SubscribeController(APIContext context) : ControllerBase
{
    private readonly APIContext _context = context;

    [HttpPost]
    public async Task<IActionResult> Subscribe(SubscribersEntity entity)
    {
        if (ModelState.IsValid)
        {
            if (await _context.Subscribers.AnyAsync(x => x.Email == entity.Email))
                return Conflict();
            

                _context.Add(entity);
                await _context.SaveChangesAsync();
                return Ok();
            
        }
        return BadRequest();

        
    }

    [HttpDelete]
    public async Task<IActionResult> Unsubscribe(string email)
    {
        if(ModelState.IsValid)
        {
            var subscriber = await _context.Subscribers.FirstOrDefaultAsync(x => x.Email == email);
            if (subscriber == null)
                return NotFound();
            

                _context.Remove(subscriber);
                await _context.SaveChangesAsync();
                return Ok();
            
        }
        return BadRequest();
    }
}
