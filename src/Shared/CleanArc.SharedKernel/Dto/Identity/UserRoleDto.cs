namespace CleanArc.SharedKernel.Dto.Identity
{
	public class UserRoleDto
	{
		public int Id { get; set; }
		public UserDto User { get; set; }
		public Role Role { get; set; }
		public DateTime CreatedUserRoleDate { get; set; }
	}
}
