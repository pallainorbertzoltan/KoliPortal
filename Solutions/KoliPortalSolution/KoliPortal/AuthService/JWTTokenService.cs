using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using KoliPortal.Lib.MODEL;

namespace KoliPortal.API.AuthService
{
    /// <summary>
    /// Digitális karszalagokhoz hasonloan, a JWTTokenService egy szolgaltatas,
    /// amely a JSON Web Token (JWT) alapu hitelesitest es jogosultsagkezelest valositja meg.
    /// Ez a szolgaltatas felelos a JWT tokenek letrehozasaert, 
    /// amelyeket a felhasznalok hitelesitesere es jogosultsagainak meghatarozasara hasznalnak.
    /// </summary>
    public class JWTTokenService
    {
        private readonly IConfiguration _configuration;

        public JWTTokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// A felhasznalo es a szerepkore alapjan letrehozza a JWT tokent.
        /// </summary>
        public string  CreateToken(Felhasznalok user, string szerepkorNev)
        {
            var issuer = _configuration["Jwt:Issuer"];
            var audience = _configuration["Jwt:Audience"];
            var key = _configuration["Jwt:Key"];
            var expires = _configuration["Jwt:ExpiresMinutes"];

            // Allitas a felhasznalo adataibol. Beletesszük a nevét, az emailjét és az ID-ját a tokenbe.
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.NameIdentifier, user.ID.ToString()),
                new Claim(ClaimTypes.GivenName, user.Nev), // Eltároljuk a teljes nevét is
                new Claim(JwtRegisteredClaimNames.Sub, user.ID.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            // A Szerepkör hozzáadása, hogy az API tudja, hogy ő Admin, Karbantartó vagy Diák
            claims.Add(new Claim(ClaimTypes.Role, szerepkorNev));

            // Titkosítás a kulcs alapján
            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var creds = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

            // A Token "megsütése" (generálása)
            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(double.Parse(expires)),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}