namespace CleanArc.SharedKernel.Dto.Identity
{
	public class RoleDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string DisplayName { get; set; }
		public DateTime CreatedDate { get; set; }
		public List<RoleClaimDto> Claims { get; set; }
		public List<UserRoleDto> Users { get; set; }
	}
}
