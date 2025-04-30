using MachineLicenseManagement.WebKeyGen.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace MachineLicenseManagement.WebKeyGen
{
    public class AuthService
    {
        private readonly PraMaschlizenzContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public AuthService(PraMaschlizenzContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ClaimsPrincipal> ValidateUserAsync(string username, string password)
        {
            //var user = await _context.Users.SingleOrDefaultAsync(u => u.Username == username);
            //if (user == null) return false;
            await Task.Delay(100); // Simulate async work

            var claimsIdentity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, username)
            }, CookieAuthenticationDefaults.AuthenticationScheme);



            return new ClaimsPrincipal(claimsIdentity);
            

        }

        private bool VerifyPasswordHash(string password, string storedHash)
        {
            // Implement your hash verification logic here
            return true;
        }

    }

}
