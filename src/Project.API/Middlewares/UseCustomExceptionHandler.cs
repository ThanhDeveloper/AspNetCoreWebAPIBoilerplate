using System.Security.Authentication;
using Microsoft.AspNetCore.Diagnostics;
using Project.Core.DTOs;
using Project.Service.Common.Exceptions;
using System.Text.Json;

namespace Project.API.Middlewares
{
    public static class UseCustomExceptionHandler
    {
        public static void UseCustomException(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(config =>
            {

                config.Run(async context =>
                {
                    context.Response.ContentType = "application/json";

                    var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();

                    if (exceptionFeature != null)
                    {
                        var statusCode = exceptionFeature.Error switch
                        {
                            NotFoundException => StatusCodes.Status404NotFound,
                            AuthenticationException => StatusCodes.Status400BadRequest,
                            ArgumentException => StatusCodes.Status400BadRequest,
                            _ => StatusCodes.Status500InternalServerError
                        };
                        context.Response.StatusCode = statusCode;
                    
                        var response = CustomResponseDto<NoContentDto>.Fail(statusCode, exceptionFeature.Error.Message);
                    
                        await context.Response.WriteAsync(JsonSerializer.Serialize(response));
                    }
                });
            });
        }
    }
}
