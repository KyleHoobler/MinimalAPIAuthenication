using System.ComponentModel.DataAnnotations;

namespace MinimalAPIAuthentication.Models.Users
{
    public record CreateUserRequest(
        [Required]string email,
        [Required]string name,
        [Required] string password    
    );
}
