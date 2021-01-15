using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using NLayerWebApiProject.API.DTOs;

namespace NLayerWebApiProject.API.Filters
{
    public class ValidationFilter: ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                ErrorDTO errorDto = new ErrorDTO();
                errorDto.StatusCode = StatusCodes.Status400BadRequest;
                IEnumerable<ModelError> modelErrors = context.ModelState.Values.SelectMany(v => v.Errors);
                modelErrors.ToList().ForEach(e =>
                {
                    errorDto.Errors.Add(e.ErrorMessage);
                });
                context.Result = new BadRequestObjectResult(errorDto);
            }
            base.OnResultExecuting(context);
        }
    }
}