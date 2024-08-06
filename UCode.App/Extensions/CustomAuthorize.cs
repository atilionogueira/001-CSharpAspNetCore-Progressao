using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace UCode.App.Extensions
{
    public class CustomAuthorize
    {
        public static bool ValidarClaimUsuario(HttpContext context, string claimName, string claimValues) 
        {
            return context.User.Identity.IsAuthenticated &&
                   context.User.Claims.Any(c => c.Type == claimName && c.Value.Contains(claimValues)) ;  
        }
    }

    public class ClaimsAuthorizeAttribute : TypeFilterAttribute 
    { 
        public ClaimsAuthorizeAttribute(string claimName, string claimValue) : base(typeof(RequisitoClaimFilter)) 
        {
            Arguments = new object[] { new Claim(claimName, claimValue) };
        }
    }

    public class RequisitoClaimFilter : IAuthorizationFilter 
    {
        private readonly Claim _claim;

        public RequisitoClaimFilter(Claim claim)
        {
            _claim = claim;

        }

        public void OnAuthorization(AuthorizationFilterContext context) 
        { 
            if(!context.HttpContext.User.Identity.IsAuthenticated) 
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    area = "Identity",
                    page = "/Account/Login",
                    ReturnUrl = context.HttpContext.Request.Path.ToString()
                }));
                return;
            }

            if (!CustomAuthorize.ValidarClaimUsuario(context.HttpContext, _claim.Type, _claim.Value)) 
            {
                context.Result = new StatusCodeResult(403);
            } 
        }
    }

}
