using Microsoft.AspNetCore.Identity;

namespace ItemCheckout.Data.Entities;

public class User: IdentityUser
{
    public string Name { get; set; }
    public string Affiliation { get; set; }
}