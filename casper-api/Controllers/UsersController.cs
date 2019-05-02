using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using casper_api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace casper_api.Controllers {
  [Route ("api/users")]
  [ApiController]
  public class UsersController : ControllerBase {
    private readonly CasperContext _context;

    public UsersController (CasperContext context) {
      _context = context;
    }
    // GET api/users
    [HttpGet]
    public async Task<ActionResult<List<User>>> GetUsers () {
      return await _context.Users.ToListAsync ();
    }

    // GET: api/users/id
    [HttpGet ("{id}")]
    public async Task<ActionResult<User>> GetUser (int id) {
      var user = await _context.Users.FindAsync (id);

      if (user == null) {
        return NotFound ();
      }

      return user;
    }

    // POST: api/users
    [HttpPost]
    public async Task<ActionResult<User>> CreateUser (User user) {
      _context.Users.Add (user);
      await _context.SaveChangesAsync ();

      return CreatedAtAction (nameof (GetUsers), new { id = user.UserId }, user);
    }

  }
}