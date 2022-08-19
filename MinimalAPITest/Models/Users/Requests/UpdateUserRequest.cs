using System.ComponentModel.DataAnnotations;

namespace MinimalAPIAuthentication.Models.Users
{
    public record UpdateUserRequest(
        [Required]Guid userId,
        string? email = null,
        string? name = null,
        string? password = null
    );
}
