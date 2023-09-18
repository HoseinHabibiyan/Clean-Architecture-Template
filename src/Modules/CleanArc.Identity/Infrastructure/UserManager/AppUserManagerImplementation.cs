using CleanArc.Identity.Domain;
using CleanArc.Identity.Infrastructure.Identity.Dtos;
using CleanArc.Identity.Infrastructure.Identity.Manager;
using CleanArc.SharedKernel.Contracts.Identity;
using CleanArc.SharedKernel.Dto.Identity;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CleanArc.Identity.Infrastructure.UserManager;

public class AppUserManagerImplementation : IAppUserManager
{
	private readonly AppUserManager _userManager;
	public AppUserManagerImplementation(AppUserManager userManager)
	{
		_userManager = userManager;
	}

	public Task<IdentityResult> CreateUser(UserDto user)
	{
		return _userManager.CreateAsync(user.Adapt<User>());
	}

	public Task<bool> IsExistUser(string phoneNumber)
	{
		return _userManager.Users.AnyAsync(c => c.PhoneNumber == phoneNumber);
	}

	public Task<bool> IsExistUserName(string userName)
	{
		return _userManager.Users.AnyAsync(c => c.UserName.Equals(userName));
	}

	public async Task<string> GeneratePhoneNumberConfirmationToken(UserDto user, string phoneNumber)
	{
		return await _userManager.GenerateChangePhoneNumberTokenAsync(user.Adapt<User>(), phoneNumber);
	}

	public async Task<UserDto?> GetUserByCode(string code)
	{
		User? user = await _userManager.Users.FirstOrDefaultAsync(c => c.GeneratedCode.Equals(code));

		if (user == null)
		{
			return null;
		}

		return user.Adapt<UserDto>();
	}

	public async Task<IdentityResult> ChangePhoneNumber(UserDto user, string phoneNumber, string code)
	{
		return await _userManager.ChangePhoneNumberAsync(user.Adapt<User>(), phoneNumber, code);
	}

	public async Task<IdentityResult> VerifyUserCode(UserDto user, string code)
	{
		var confirmationResult = await _userManager.VerifyUserTokenAsync(
			user.Adapt<User>(), CustomIdentityConstants.OtpPasswordLessLoginProvider, CustomIdentityConstants.OtpPasswordLessLoginPurpose, code);

		if (confirmationResult)
			await _userManager.UpdateSecurityStampAsync(user.Adapt<User>());

		return confirmationResult
			? IdentityResult.Success
			: IdentityResult.Failed(new IdentityError() { Description = "Incorrect Code" });
	}

	public Task<string> GenerateOtpCode(UserDto user)
	{
		return _userManager.GenerateUserTokenAsync(
			user.Adapt<User>(), CustomIdentityConstants.OtpPasswordLessLoginProvider, CustomIdentityConstants.OtpPasswordLessLoginPurpose);
	}

	public Task<UserDto?> GetUserByPhoneNumber(string phoneNumber)
	{
		return _userManager.Users.ProjectToType<UserDto>().FirstOrDefaultAsync(c => c.PhoneNumber.Equals(phoneNumber));
	}

	public async Task<SignInResult> AdminLogin(UserDto user, string password)
	{
		return await _userManager.CheckPasswordAsync(user.Adapt<User>(), password) ? SignInResult.Success : SignInResult.Failed;
	}

	public async Task<UserDto?> GetByUserName(string userName)
	{
		User? user = await _userManager.FindByNameAsync(userName);

		if (user == null)
		{
			return null;
		}

		return user.Adapt<UserDto>();
	}

	public async Task<UserDto?> GetUserByIdAsync(int userId)
	{
		User? user =  await _userManager.FindByIdAsync(userId.ToString());

		if (user == null)
		{
			return null;
		}

		return user.Adapt<UserDto>();
	}

	public async Task<List<UserDto>> GetAllUsersAsync()
	{
		return await _userManager.Users.AsNoTracking().ProjectToType<UserDto>().ToListAsync();
	}

	public async Task<IdentityResult> CreateUserWithPasswordAsync(UserDto user, string password)
	{
		return await _userManager.CreateAsync(user.Adapt<User>(), password);
	}

	public async Task<IdentityResult> AddUserToRoleAsync(UserDto user, RoleDto role)
	{
		ArgumentNullException.ThrowIfNull(role, nameof(role));
		ArgumentNullException.ThrowIfNull(role.Name, nameof(role.Name));

		return await _userManager.AddToRoleAsync(user.Adapt<User>(), role.Name);
	}

	public async Task<IdentityResult> IncrementAccessFailedCountAsync(UserDto user)
	{
		return await _userManager.AccessFailedAsync(user.Adapt<User>());
	}

	public async Task<bool> IsUserLockedOutAsync(UserDto user)
	{
		var lockoutEndDate = await _userManager.GetLockoutEndDateAsync(user.Adapt<User>());

		return lockoutEndDate.HasValue && lockoutEndDate.Value > DateTimeOffset.Now;
	}

	public async Task ResetUserLockoutAsync(UserDto user)
	{
		await _userManager.SetLockoutEndDateAsync(user.Adapt<User>(), null);
		await _userManager.ResetAccessFailedCountAsync(user.Adapt<User>());
	}

	public async Task UpdateUserAsync(UserDto user)
	{
		await _userManager.UpdateAsync(user.Adapt<User>());
	}

	public async Task UpdateSecurityStampAsync(UserDto user)
	{
		await _userManager.UpdateSecurityStampAsync(user.Adapt<User>());
	}
}