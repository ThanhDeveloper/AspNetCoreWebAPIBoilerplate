using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using RepositoryPattern.Dtos;

namespace RepositoryPattern.Common.Exceptions
{
    public class HttpGlobalExceptionFilter : ExceptionFilterAttribute
    {
        private readonly ILogger<HttpGlobalExceptionFilter> _logger;

        public HttpGlobalExceptionFilter(ILogger<HttpGlobalExceptionFilter> logger)
        {
        }
        
        public override async Task OnExceptionAsync(ExceptionContext context)
        {
            var exception = context.Exception;
            //ApiErrorResult apiErrorResult;
            var apiResponse = ApiResponse<string>.Fail(exception.Message);

            if (context.Exception.GetType() == typeof(BusinessException) || context.Exception.GetType().BaseType == typeof(BusinessException))
            {
                // handle business exception
                var businessException = (BusinessException)exception;
                apiResponse.error_code = string.IsNullOrWhiteSpace(businessException.ErrorCode) ? exception.GetType().Name : businessException.ErrorCode;
                apiResponse.message = exception.Message;

                context.Result = new BadRequestObjectResult(apiResponse);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            else
            {
                // if it's not one of the expected exception, set it to 500
                var code = HttpStatusCode.InternalServerError;

                //TODO:Mapping if (exception is NotFoundExe) code = HttpStatusCode.NotFound;
                switch (exception)
                {
                    case EntityNotFoundException _:
                        code = HttpStatusCode.NotFound;
                        apiResponse.error_code = exception.Message;
                        apiResponse.message = "Resource not found";
                        break;
                    case ArgumentNullException _:
                        code = HttpStatusCode.BadRequest;
                        break;
                    case InvalidArgumentException _:
                        code = HttpStatusCode.BadRequest;
                        break;
                    case HttpRequestException _:
                        code = HttpStatusCode.BadRequest;
                        break;
                    case UnauthorizedAccessException _:
                        code = HttpStatusCode.Unauthorized;
                        apiResponse.error_code = exception.Message;
                        apiResponse.message = "Authentication failed";
                        break;
                    case KeyNotFoundException _:
                        code = HttpStatusCode.NotFound;
                        apiResponse.error_code = exception.Message;
                        apiResponse.message = "Resource not found";
                        break;
                    default:
                        code = HttpStatusCode.InternalServerError;
                        apiResponse.message = "INTERNAL_SERVER_ERROR";
                        apiResponse.message = "Internal server error";
                        break;
                }
                context.Result = new ObjectResult(apiResponse);
                context.HttpContext.Response.StatusCode = (int)code;
            }
            context.ExceptionHandled = true;
        }
    }
}
