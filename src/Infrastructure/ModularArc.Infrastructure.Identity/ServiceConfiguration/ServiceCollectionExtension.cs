using System.Security.Claims;
using System.Text;
using CleanArc.Application.Contracts;
using CleanArc.Application.Contracts.Identity;
using CleanArc.Application.Models.ApiResult;
using CleanArc.Domain.Entities.User;
using CleanArc.Infrastructure.Identity.Identity;
using CleanArc.Infrastructure.Identity.Identity.Dtos;
using CleanArc.Infrastructure.Identity.Identity.Extensions;
using CleanArc.Infrastructure.Identity.Identity.Manager;
using CleanArc.Infrastructure.Identity.Identity.PermissionManager;
using CleanArc.Infrastructure.Identity.Identity.SeedDatabaseService;
using CleanArc.Infrastructure.Identity.Identity.Store;
using CleanArc.Infrastructure.Identity.Identity.validator;
using CleanArc.Infrastructure.Identity.Jwt;
using CleanArc.Infrastructure.Identity.UserManager;
using CleanArc.SharedKernel.Contracts;
using CleanArc.SharedKernel.Contracts.Identity;
using CleanArc.SharedKernel.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace CleanArc.Infrastructure.Identity.ServiceConfiguration;

public static class ServiceCollectionExtension
{
 
}