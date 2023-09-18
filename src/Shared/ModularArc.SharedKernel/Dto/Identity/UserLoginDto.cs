namespace ModularArc.SharedKernel.Dto.Identity
{
    public class UserLoginDto
    {
        public int Id { get; set; }
        public UserDto User { get; set; }
        public DateTime LoggedOn { get; set; }
    }
}
