using CleanArc.Identity.Domain;
using CleanArc.SharedKernel.Dto.Identity;
using CleanArc.SharedKernel.Dto.Identity.Models;
using Microsoft.AspNetCore.Identity;

namespace CleanArc.SharedKernel.Contracts.Identity;

public interface IRoleManagerService
{
	Task<List<GetRolesDto>> GetRolesAsync();
	Task<IdentityResult> CreateRoleAsync(CreateRoleDto model);
	Task<bool> DeleteRoleAsync(int roleId);
	Task<List<ActionDescriptionDto>> GetPermissionActionsAsync();
	Task<RolePermissionDto> GetRolePermissionsAsync(int roleId);
	Task<bool> ChangeRolePermissionsAsync(EditRolePermissionsDto model);
	Task<Role> GetRoleByIdAsync(int roleId);
}