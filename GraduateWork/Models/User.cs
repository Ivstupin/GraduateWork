using GraduateWork.Models.Enums;

namespace GraduateWork.Models;
public record User
{
    public UserType UserType { get; set; }
    public string Email { get; init; } = string.Empty;
    public string Password { get; init; } = string.Empty;
}