using GeekShopping.Identity.Enumerations.Base;
using GeekShopping.Identity.Models;
using Microsoft.AspNetCore.Identity;

namespace GeekShopping.Identity.Enumerations;

public class ApplicationUserEnumeration : EnumerationBase<ApplicationUserEnumeration, ApplicationUser>
{
    public static readonly ApplicationUser ADMIN = new(
        1, "Leo", "LEO", "leonardotdd06@gmail.com", "LEONARDOTDD06@GMAIL.COM",
        true, "+55 (12) 98304-3718", "Leonardo", "Admin", HashPassword(ADMIN, "Leonardo123$")
    );
    public static readonly ApplicationUser CLIENT = new(
        2, "Leo Client", "LEO CLIENT", "leonardotdd06@outlook.com", "LEONARDOTDD06@OUTLOOK.COM",
        true, "+55 (12) 98304-3718", "Leonardo", "Client", HashPassword(CLIENT, "Leonardo123$")
    );

    private static string HashPassword(ApplicationUser user, string password)
        => new PasswordHasher<ApplicationUser>().HashPassword(user, password);
}
