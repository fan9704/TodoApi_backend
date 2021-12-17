using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi_backend.Data;
using TodoApi_backend.Models;

namespace TodoApi_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserContext _context;

        public AccountController(UserContext context)
        {
            _context = context;
        }

        // GET: api/Account
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUser()
        {
            return await _context.User.ToListAsync();
        }

        // GET: api/Account/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.User.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/Account/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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
        /*
        // POST: api/Account/Login
        // TODO Login
        [HttpPost("Login")]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            var checkuser = _context.User
      .FromSqlRaw("SELECT * FROM User where username = {0}", user.Username)
      .ToList();
            Console.WriteLine(HttpContext.Response);
           // _context.User.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }*/
        [HttpPost("Login")]
        public  IActionResult Login([FromBody] User user)
        {
            Console.WriteLine(user.Username);
          var check = _context.User
              .Where(u=> u.Username == user.Username && HMACSHA256(user.Password, "ASP.NET")== u.Password)
              .FirstOrDefault();
          if (check != null) {
                HttpContext.Session.SetString("Login","Success");//add app in configure
                HttpContext.Response.Cookies.Append("User", user.Username);
                return Ok(true);
            }
          else
          {
                //return new JsonResult(true);
              return Ok(false);
          }
        }
        [HttpGet("Logout")]
        public ActionResult Logout()
        {
           HttpContext.Session.Clear();
            HttpContext.Response.Cookies.Delete("User");
            return Ok("Logout Success");
        }
        // DELETE: api/Account/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.User.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _context.User.Any(e => e.Id == id);
        }
        private static string HMACSHA256(string message, string key)
        {
            var encoding = new System.Text.UTF8Encoding();
            byte[] keyByte = encoding.GetBytes(key);
            byte[] messageBytes = encoding.GetBytes(message);
            using (var hmacSHA256 = new HMACSHA256(keyByte))
            {
                byte[] hashMessage = hmacSHA256.ComputeHash(messageBytes);
                return BitConverter.ToString(hashMessage).Replace("-", "").ToLower();
            }
        }
    }
}
