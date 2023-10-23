namespace Sakila.Application.Dtos.Common
{
    public class BaseTokenDto
    {
        public string? Token { get; set; }
        public string? RefreshToken { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
