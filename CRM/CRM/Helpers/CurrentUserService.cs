using BusinessLayer.Abstract;
using System.Security.Claims;
namespace CRM.Helpers
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string UserName => _httpContextAccessor.HttpContext?.User?.Identity?.Name ?? "Misafir";

        public string UserRole => _httpContextAccessor.HttpContext?.User?.Claims
        .FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value ?? "Kullanıcı";

        public int UserId => int.TryParse(
        _httpContextAccessor.HttpContext?.User?.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value,
        out int userId) ? userId : 0;
    }
}
