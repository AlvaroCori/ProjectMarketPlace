using System.Net;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using ProjectMarketPlace.Common;
namespace ProjectMarketPlace.Extension
{
    public static class ExceptionHandlerExtension
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(error =>
            {
                error.Run(async context =>
                {
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        context.Response.StatusCode = (int) HttpStatusCode.BadRequest;
                        context.Response.ContentType = "application/json";
                        await context.Response.WriteAsJsonAsync(new BaseResponse<string>(contextFeature.Error.GetBaseException().Message));
                    }
                });
            });
        }
        private static HttpStatusCode ErrorCode(in Exception e)
        {
            switch (e)
            {
                case CustomException:
                    return HttpStatusCode.BadRequest;
                default: 
                    return HttpStatusCode.InternalServerError;
            }
        }
    }
}
