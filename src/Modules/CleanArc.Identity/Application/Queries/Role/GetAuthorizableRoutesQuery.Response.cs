namespace CleanArc.Identity.Application.Queries.Role;

public record GetAuthorizableRoutesQueryResponse(string RouteKey, string AreaName, string ControllerName, string ActionName, string ControllerDescription);