﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataBase.Entities;

namespace DataBase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserTablesController : ControllerBase
    {
        private readonly MydatabaseContext _context;

        public UserTablesController(MydatabaseContext context)
        {
            _context = context;
        }

        // GET: api/UserTables
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserTable>>> GetUserTables()
        {
            return await _context.UserTables.ToListAsync();
        }

        [HttpGet("output/{lastname}")]
        public async Task<ActionResult<IEnumerable<UserTable>>> GetUsers(string lastname)
        {
            var user = _context.UserTables.Where(curr => curr.Lastname.Equals(lastname, StringComparison.OrdinalIgnoreCase));
            if (user == null)
            {
                return NotFound();
            }
            return await user.ToListAsync();
        }

        // GET: api/UserTables/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserTable>> GetUserTable(int id)
        {
            var userTable = await _context.UserTables.FindAsync(id);

            if (userTable == null)
            {
                return NotFound();
            }

            return userTable;
        }

        // PUT: api/UserTables/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserTable(int id, UserTable userTable)
        {
            if (id != userTable.Id)
            {
                return BadRequest();
            }

            _context.Entry(userTable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserTableExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/UserTables
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserTable>> PostUserTable(UserTable userTable)
        {
            _context.UserTables.Add(userTable);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserTable", new { id = userTable.Id }, userTable);
        }

        // DELETE: api/UserTables/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserTable(int id)
        {
            var userTable = await _context.UserTables.FindAsync(id);
            if (userTable == null)
            {
                return NotFound();
            }

            _context.UserTables.Remove(userTable);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserTableExists(int id)
        {
            return _context.UserTables.Any(e => e.Id == id);
        }
    }
}
