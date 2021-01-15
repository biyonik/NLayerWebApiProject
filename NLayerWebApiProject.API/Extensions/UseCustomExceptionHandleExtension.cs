using System.Text.Json;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using NLayerWebApiProject.API.DTOs;

namespace NLayerWebApiProject.API.Extensions
{
    public static class UseCustomExceptionHandleExtension
    {
        public static void UseCustomExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(config =>
            {
                config.Run(async context =>
                {
                    context.Response.StatusCode = 500;
                    context.Response.ContentType = "application/json";
                    var error = context.Features.Get<IExceptionHandlerFeature>();
                    if (error != null)
                    {
                        var ex = error.Error;
                        ErrorDTO errorDto = new ErrorDTO();
                        errorDto.StatusCode = 500;
                        errorDto.Errors.Add(ex.Message);
                        await context.Response.WriteAsync(JsonSerializer.Serialize(errorDto));
                    }
                });
            });
        }
    }
}