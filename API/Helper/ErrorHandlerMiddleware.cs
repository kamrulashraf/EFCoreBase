﻿using Core.AppExceptions;
using Core.ILogger;
using System.Net;
using System.Text.Json;

namespace API.Helper
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogManager<ErrorHandlerMiddleware> _logger;
        public ErrorHandlerMiddleware(RequestDelegate next, ILogManager<ErrorHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                _logger.LogError(error.Message + "{@error}", error);
                var response = context.Response;
                response.ContentType = "application/json";
                switch (error)
                {
                    case AppException e:
                        response.StatusCode = (int) e.StatusCode;
                        break;
                    default:
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }

                var result = JsonSerializer.Serialize(new { message = error?.Message });
                await response.WriteAsync(result);
            }
        }
    }
}
