
namespace CleanArc.SharedKernel.Dto.Identity.Models;

public class RolePermissionDto
{
	public List<string> Keys { get; set; } = new List<string>();

	public RoleDto Role { get; set; }

	public int RoleId { get; set; }

	public List<ActionDescriptionDto> Actions { get; set; }
}