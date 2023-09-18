using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ModularArc.WebFramework.Swagger;

public class CustomTokenRequiredOperationFilter : IOperationFilter
{
    private readonly SecurityRequirementsOperationFilter<RequireTokenWithoutAuthorizationAttribute> filter;

    public CustomTokenRequiredOperationFilter()
    {
        filter =
            new SecurityRequirementsOperationFilter<RequireTokenWithoutAuthorizationAttribute>(
                _ => Array.Empty<string>(), false);
    }

    public void Apply(OpenApiOperation operation, OperationFilterContext context) => filter.Apply(operation, context);


}
