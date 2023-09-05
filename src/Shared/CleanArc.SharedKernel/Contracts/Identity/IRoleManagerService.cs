using CleanArc.SharedKernel.Dto.Identity;
using CleanArc.SharedKernel.Dto.Identity.Models;
using Microsoft.AspNetCore.Identity;

namespace CleanArc.SharedKernel.Contracts.Identity;

public interface IRoleManagerService
{
	Task<List<RoleDto>> GetRolesAsync();
	Task<IdentityResult> CreateRoleAsync(string roleName);
	Task<bool> DeleteRoleAsync(int roleId);
	Task<List<ActionDescriptionDto>> GetPermissionActionsAsync();
	Task<RolePermissionDto?> GetRolePermissionsAsync(int roleId);
	Task<bool> ChangeRolePermissionsAsync(int RoleId , List<string> Permissions);
	Task<RoleDto?> GetRoleByIdAsync(int roleId);
}