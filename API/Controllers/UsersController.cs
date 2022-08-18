using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        public Data.DataContext _context { get; }
        public UsersController(Data.DataContext context )
        {
            _context = context; 
        }

        // get list of users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers ()
        {
            return await _context.Users.ToListAsync();
        }

        // get single user
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUsers (int id)
        {
            return await _context.Users.FindAsync(id);
        }

    }
}