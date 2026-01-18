using KutuphaneOtomasyonu.Web.Models.Entities;

namespace KutuphaneOtomasyonu.Web.Services;

public interface IAuthService
{
    Task<Member?> ValidateUserAsync(string email, string password);
    Task<Member?> GetUserByEmailAsync(string email);
    Task<Member?> GetUserByIdAsync(int id);
    string HashPassword(string password);
    bool VerifyPassword(string password, string hash);
}
