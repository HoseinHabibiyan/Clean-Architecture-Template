using Microsoft.AspNetCore.Identity;
using ModularArc.SharedKernel.Dto.Identity;
using ModularArc.SharedKernel.Dto.Identity.Models;

namespace ModularArc.SharedKernel.Contracts.Identity;

public interface IRoleManagerService
{
    Task<List<RoleDto>> GetRolesAsync();
    Task<IdentityResult> CreateRoleAsync(string roleName);
    Task<bool> DeleteRoleAsync(int roleId);
    Task<List<ActionDescriptionDto>> GetPermissionActionsAsync();
    Task<RolePermissionDto> GetRolePermissionsAsync(int roleId);
    Task<bool> ChangeRolePermissionsAsync(int RoleId, List<string> Permissions);
    Task<RoleDto> GetRoleByIdAsync(int roleId);
}