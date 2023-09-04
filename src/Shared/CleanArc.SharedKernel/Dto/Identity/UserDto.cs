namespace CleanArc.SharedKernel.Dto.Identity
{
	public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FamilyName { get; set; }
        public string GeneratedCode { get; set; }

        public List<UserRoleDto> UserRoles { get; set; }
        public List<UserLoginDto> Logins { get; set; }
        public List<UserClaimDto> Claims { get; set; }
        public List<UserTokenDto> Tokens { get; set; }
        public List<UserRefreshTokenDto> UserRefreshTokens { get; set; }
    }
}
