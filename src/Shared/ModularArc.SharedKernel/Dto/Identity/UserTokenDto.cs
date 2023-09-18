namespace ModularArc.SharedKernel.Dto.Identity
{
    public class UserTokenDto
    {
        public int Id { get; set; }
        public UserDto User { get; set; }
        public DateTime GeneratedTime { get; set; }
    }
}
