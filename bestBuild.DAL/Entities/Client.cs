using Microsoft.AspNetCore.Identity;

namespace bestBuild.DAL.Entities;

public class Client : IdentityUser
{
    public byte[] Photo { get; set; } = null!;
    public List<Order> Orders { get; set; } = null!;
}