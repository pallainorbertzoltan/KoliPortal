using KoliPortal.API.AuthService;
using KoliPortal.Lib.DATA;
using KoliPortal.Lib.MODEL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KoliPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly KoliportalDBContext _context;
        private readonly JWTTokenService _jwtService;

        public AuthController(KoliportalDBContext context, JWTTokenService jwtService)
        {
            _context = context;
            _jwtService = jwtService;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] Login loginAdat)
        {
            var user = await _context.Felhasznalok
                .FirstOrDefaultAsync(x => x.Email == loginAdat.Email);

            // BCrypt verifikáció
            if (user == null || !BCrypt.Net.BCrypt.Verify(loginAdat.Jelszo, user.Jelszo))
            {
                return Unauthorized("Hibás email vagy jelszó!");
            }

            var Token = _jwtService.CreateToken(user, user.SzerepkorID.ToString());
            return Ok(new { Token });
        }

        [HttpPost("Register")]
        // Itt 'Felhasznalok' modellt várunk, nem 'Login'-t
        public async Task<IActionResult> Register([FromBody] Felhasznalok ujUser)
        {
            // Ellenőrizzük, foglalt-e az email
            if (await _context.Felhasznalok.AnyAsync(x => x.Email == ujUser.Email))
            {
                return BadRequest("Ez az email már használatban van!");
            }

            // Jelszó hashelése BCrypt-tel (itt a Blazor által küldött sima jelszót titkosítjuk)
            ujUser.Jelszo = BCrypt.Net.BCrypt.HashPassword(ujUser.Jelszo);

            // Mentés az adatbázisba. 
            // A Nev és a SzerepkorID már benne van az 'ujUser' objektumban a Blazorból
            _context.Felhasznalok.Add(ujUser);
            await _context.SaveChangesAsync();

            return Ok(new { Message = "Sikeres regisztráció!" });
        }
    }
}