﻿using Infrastructure.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebAPIProject.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CoursesController(APIContext context) : ControllerBase
{
    private readonly APIContext _context = context;

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _context.Courses.ToListAsync());
}
