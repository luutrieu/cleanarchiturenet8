using Application.DTOs.Request.Account;
using Application.DTOs.Response.Account;
using Application.DTOs.Response;

namespace Application.Services
{
    public interface IAccountService
    {
        Task CreateAdmin();
        Task<GeneralResponse> CreateAccountAsync(CreateAccountDTO model);
        Task<LoginResponse> LoginAccountAsync(LoginDTO model);
        Task<LoginResponse> RefreshTokenAsync(RefreshTokenDTO model);
        Task<GeneralResponse> CreateRoleAsync(CreateRoleDTO model);
        //Task<IEnumerable<GetRoleDTO>> GetRoleAsync();
        Task<IEnumerable<GetUsersWithRolesResponseDTO>> GetUserWithRolesAsync();
        Task<GeneralResponse> ChangeUserRoleAsync(ChangeUserRoleRequestDTO model);
    }
}
