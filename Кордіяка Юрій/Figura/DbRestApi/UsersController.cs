using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Entities;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly CisharpContext _context;

        public UsersController(CisharpContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        [HttpGet("getUser/{LastName}")]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers(string LastName)
        {
            var user = _context.Users.Where(u => u.LastName.Equals(LastName, StringComparison.OrdinalIgnoreCase));
            if (user == null)
            {
                return NotFound();
            }
            return await user.ToListAsync();
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.PersonId == id);
        }
    }
}
