using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Policy;
using Microsoft.AspNetCore.Mvc.Filters;
using ProjectMarketPlace.Common;

namespace ProjectMarketPlace.Middlewares
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class CustomAuthenticationAttribute : ActionFilterAttribute, IAsyncAuthorizationFilter
    {

        //public AuthorizationPolicy Policy { get; }
        public AuthorizationPolicy? Policy { get; }
        public CustomAuthenticationAttribute()
        {
            Policy = new AuthorizationPolicyBuilder().AddAuthenticationSchemes("CustomAuth").RequireAuthenticatedUser().Build();
        }
        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            if (context == null)
            {
                throw new CustomException(nameof(context));
            }
            if (context == null || context.HttpContext == null || context.HttpContext.Request == null || context.HttpContext.Request.Headers == null)
            {
                throw new CustomException("Header no valido");
            }
            if (context.HttpContext.Request.Headers.ContainsKey("Authorization"))
            {
                throw new CustomException("Acceso no autorizado");
            }
            if (context.Filters.Any(item => item is IAllowAnonymous))
            {
                return;
            }
            
            var policyEvaluator = context.HttpContext.RequestServices.GetRequiredService<IPolicyEvaluator>();
            var authenticateResult = await policyEvaluator.AuthenticateAsync(Policy, context.HttpContext);
            var authorizationResult = await policyEvaluator.AuthorizeAsync(Policy, authenticateResult, context.HttpContext, context);
            if (authorizationResult.Challenged)
            {
                throw new CustomException("Acceso no autorizado.");
            }
            
        }
    }
}
