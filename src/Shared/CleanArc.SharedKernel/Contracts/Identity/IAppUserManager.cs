using CleanArc.SharedKernel.Dto.Identity;
using Microsoft.AspNetCore.Identity;

namespace CleanArc.SharedKernel.Contracts.Identity;

public interface IAppUserManager
{
	Task<IdentityResult> CreateUser(UserDto user);
	Task<bool> IsExistUser(string phoneNumber);
	Task<bool> IsExistUserName(string userName);
	Task<string> GeneratePhoneNumberConfirmationToken(UserDto user, string phoneNumber);
	Task<UserDto> GetUserByCode(string code);
	Task<IdentityResult> ChangePhoneNumber(UserDto user, string phoneNumber, string code);
	Task<IdentityResult> VerifyUserCode(UserDto user, string code);
	Task<string> GenerateOtpCode(UserDto user);
	Task<UserDto> GetUserByPhoneNumber(string phoneNumber);
	Task<SignInResult> AdminLogin(UserDto user, string password);
	Task<UserDto> GetByUserName(string userName);
	Task<UserDto> GetUserByIdAsync(int userId);
	Task<List<UserDto>> GetAllUsersAsync();
	Task<IdentityResult> CreateUserWithPasswordAsync(UserDto user, string password);
	Task<IdentityResult> AddUserToRoleAsync(UserDto user, RoleDto role);
	Task<IdentityResult> IncrementAccessFailedCountAsync(UserDto user);
	Task<bool> IsUserLockedOutAsync(UserDto user);
	Task ResetUserLockoutAsync(UserDto user);
	Task UpdateUserAsync(UserDto user);
	Task UpdateSecurityStampAsync(UserDto user);
}