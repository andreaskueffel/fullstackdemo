using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace MachineLicenseManagement.WebKeyGen.Pages.Auth
{
    [IgnoreAntiforgeryToken]
    public class LoginModel : PageModel
    {
        IHttpContextAccessor HttpContextAccessor { get; }
        AuthService AuthService { get; }
        public LoginModel(IHttpContextAccessor httpContextAccessor, AuthService authService)
        {
            HttpContextAccessor = httpContextAccessor;
            AuthService = authService;
        }
        public async Task<IActionResult> OnGetAsync(bool signout, string ReturnUrl)
        {
            if (signout)
            {
                if (HttpContextAccessor.HttpContext != null)
                {
                    await HttpContextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                }
            }
            //if (ReturnUrl == null)
            //    return Page();
            if (ReturnUrl == null || ReturnUrl == "")
                return Redirect("/");
            else
                return Redirect("/" + ReturnUrl.TrimStart('/'));
        }
        public async Task<IActionResult> OnPostAsync(WebKeyGen.Components.Pages.Login.LoginModel loginModel)
        {
            var claimsIdentity = await AuthService.ValidateUserAsync(loginModel.Username, loginModel.Password);
            var authProperties = new AuthenticationProperties
            {
                IsPersistent = true
            };
            if (HttpContextAccessor.HttpContext != null)
            {
                await HttpContextAccessor.HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties
                );
            }
            return Redirect("/");
        }
    }
}
