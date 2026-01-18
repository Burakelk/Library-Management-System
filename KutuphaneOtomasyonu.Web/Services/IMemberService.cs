using KutuphaneOtomasyonu.Web.Models.Entities;
using KutuphaneOtomasyonu.Web.Models.ViewModels;

namespace KutuphaneOtomasyonu.Web.Services;

public interface IMemberService
{
    Task<List<MemberListViewModel>> GetAllMembersAsync();
    Task<List<Member>> GetActiveMembersAsync();
    Task<Member?> GetMemberByIdAsync(int id);
    Task<int> AddMemberAsync(MemberCreateViewModel model);
    Task UpdateMemberAsync(MemberEditViewModel model);
    Task SetMemberStatusAsync(int memberId, string status);
    Task ChangePasswordAsync(int memberId, string currentPassword, string newPassword);
    Task ResetPasswordByEmailAsync(string email, string newPassword);
    Task<int> GetMemberCountAsync();
}
