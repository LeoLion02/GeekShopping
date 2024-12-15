using Microsoft.AspNetCore.Identity;

namespace GeekShopping.Identity.Models;

public class ApplicationUser : IdentityUser<int>
{
    public ApplicationUser() { }

    public ApplicationUser(
        int id,
        string userName,
        string normalizedUserName,
        string email,
        string normalizedEmail,
        bool emailConfirmed,
        string phoneNumber,
        string firstName,
        string lastName,
        string passwordHash
    )
    {
        Id = id;
        UserName = userName;
        NormalizedUserName = normalizedUserName;
        Email = email;
        NormalizedEmail = normalizedEmail;
        EmailConfirmed = emailConfirmed;
        PhoneNumber = phoneNumber;
        FirstName = firstName;
        LastName = lastName;
        PasswordHash = passwordHash;
    }

    public ApplicationUser(
        string firstName,
        string lastName,
        string userName,
        string email,
        bool emailConfirmed = true
    )
    {
        UserName = userName;
        Email = email;
        FirstName = firstName;
        LastName = lastName;
        EmailConfirmed = emailConfirmed;
    }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullName => $"{FirstName} {LastName}";
}

