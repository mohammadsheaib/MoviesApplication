using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

public class CustomAuthorizationFilter : IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        if (!context.ActionDescriptor.DisplayName.Contains("MoviesApplication.Controllers.AuthenticationController.Login"))
        {
            // Check if the user is authorized
            if (!context.HttpContext.User.Identity.IsAuthenticated)
            {
                // If the user is not authorized, return a 401 Unauthorized status code
                context.Result = new UnauthorizedResult();
            }
        }
    }
}
