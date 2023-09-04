using CleanArc.SharedKernel.Contracts;

namespace CleanArc.SharedKernel.Dto.Identity.Models;

public class GetRolesDto : ICreateMapper<Role>
{
	public string Id { get; set; }
	public string Name { get; set; }
}