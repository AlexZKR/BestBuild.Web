using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace bestBuild.DAL.Entities;
// Add profile data for application users by adding properties to the ClientCred class
public class ClientCred : IdentityUser
{
    [Required]
    [PersonalData]
    public string? UserFirstName { get; set; }
    [Required]
    [PersonalData]
    public string? UserLastName { get; set; }
    [Required]
    [PersonalData]
    public override string? PhoneNumber { get => base.PhoneNumber; set => base.PhoneNumber = value; }
    [Range(0, 1)]
    public double PersonalDiscount { get; set; }
    public double AmoutOfRedemption { get; set; }
}

