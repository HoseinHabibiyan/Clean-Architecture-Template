using CleanArc.Application.Profiles;

namespace CleanArc.Identity.Application.Queries.User;

public record GetUsersQueryResponse : ICreateMapper<Domain.User>
{
    public string UserName { get; set; }
    public string Email { get; set; }
    public int UserId { get; set; }
}