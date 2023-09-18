namespace ModularArc.SharedKernel.Dto.Identity;

public class UserRefreshTokenDto
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public UserDto User { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsValid { get; set; }
}