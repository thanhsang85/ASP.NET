using System.ComponentModel.DataAnnotations;

namespace MyApi.Dtos
{
    public class RegisterDto
    {
        [Required] public string FullName { get; set; } = string.Empty;
        [Required, EmailAddress] public string Email { get; set; } = string.Empty;
        [Required, MinLength(6)] public string Password { get; set; } = string.Empty;
    }

    public class LoginDto
    {
        [Required, EmailAddress] public string Email { get; set; } = string.Empty;
        [Required] public string Password { get; set; } = string.Empty;
    }

    public class AuthResponseDto
    {
        public string Token { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? FullName { get; set; }
        public DateTime ExpiresAt { get; set; }
    }

    public class ContactDto
    {
        [Required] public string Name { get; set; } = string.Empty;
        [Required, EmailAddress] public string Email { get; set; } = string.Empty;
        [Required, StringLength(2000)] public string Message { get; set; } = string.Empty;
    }

    public class ProductDto
    {
        [Required, StringLength(200)] public string Name { get; set; } = string.Empty;
        [StringLength(1000)] public string? Description { get; set; }
        [Range(0, double.MaxValue)] public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
    }
}
