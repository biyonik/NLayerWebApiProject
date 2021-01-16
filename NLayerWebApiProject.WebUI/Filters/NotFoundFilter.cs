using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NLayerWebApiProject.Core.Abstract;
using NLayerWebApiProject.Core.Services;
using NLayerWebApiProject.WebUI.DTOs;

namespace NLayerWebApiProject.WebUI.Filters
{
    public class NotFoundFilter<TEntity>: IAsyncActionFilter
    where TEntity: class, IEntity, new()
    {
        private readonly IService<TEntity> _service;

        public NotFoundFilter(IService<TEntity> service)
        {
            _service = service;
        }

        
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            int id = (int)context.ActionArguments.Values.FirstOrDefault();
            var entity = await _service.GetByIdAsync(id);
            if (entity == null)
            {
                ErrorDTO errorDto = new ErrorDTO();
                errorDto.StatusCode = StatusCodes.Status404NotFound;
                errorDto.Errors.Add($"Id değeri {id} olan nesne veritabanında bulunamadı");
                context.Result = new RedirectToActionResult("Error", "Home", errorDto);
            }
            else
            {
                await next();
            }
        }
    }
}