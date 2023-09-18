namespace ModularArc.SharedKernel.Dto.Identity
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FamilyName { get; set; }
        public string GeneratedCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public List<UserRoleDto> UserRoles { get; set; }
        public List<UserLoginDto> Logins { get; set; }
        public List<UserClaimDto> Claims { get; set; }
        public List<UserTokenDto> Tokens { get; set; }
        public List<UserRefreshTokenDto> UserRefreshTokens { get; set; }
    }
}
