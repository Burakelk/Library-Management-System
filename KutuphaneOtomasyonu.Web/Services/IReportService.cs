using KutuphaneOtomasyonu.Web.Models.ViewModels;

namespace KutuphaneOtomasyonu.Web.Services;

public interface IReportService
{
    Task<List<TopBookViewModel>> GetTopBooksLast30DaysAsync();
    Task<List<MemberLoanReportViewModel>> GetMemberLoanReportsAsync();
}
