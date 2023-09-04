namespace CleanArc.SharedKernel.Dto.Identity.Models;

public class EditRolePermissionsDto
{
	public int RoleId { get; set; }
	public List<string> Permissions { get; set; }
}