using GeekShopping.Identity.Enumerations;
using GeekShopping.Identity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GeekShopping.Identity.Pages.Account.SignIn;

[SecurityHeaders]
[AllowAnonymous]
public class Index : PageModel
{
    [BindProperty]
    public SignInViewModel Input { get; set; }

    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public Index(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task<IActionResult> OnPost()
    {
        if (!ModelState.IsValid) return Page();

        var applicationUser = new ApplicationUser(
            Input.FirstName, Input.LastName,
            Input.Username, Input.Email
        );

        var result = await _userManager.CreateAsync(applicationUser, Input.Password);
        if (!result.Succeeded) 
        {
            result.Errors.ToList().ForEach(error => ModelState.AddModelError(error.Code, error.Description));
            return Page();
        }

        await _userManager.AddToRoleAsync(applicationUser, IdentityRoleEnumeration.CLIENT.Name);
        ViewData.Add("toastMessage", "Account created successfully!");
        return RedirectToPage("/Account/Login/Index");
    }
}
