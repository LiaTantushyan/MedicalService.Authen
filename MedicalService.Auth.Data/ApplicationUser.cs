using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalService.Auth.Data
{
    public class ApplicationUser : IdentityUser<Guid>
    {
    }
}
