namespace ModularArc.SharedKernel.Dto.Identity
{
    public class UserRoleDto
    {
        public int Id { get; set; }
        public UserDto User { get; set; }
        public RoleDto Role { get; set; }
        public DateTime CreatedUserRoleDate { get; set; }
    }
}
