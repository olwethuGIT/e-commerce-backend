using api.IData;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace api.Helpers
{
    public class LogUserActivity : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var resultContext = await next();

            var username = resultContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var repo = resultContext.HttpContext.RequestServices.GetService<IStoreRepository>();
            var user = await repo.GetUser(username);
            user.LastActive = DateTime.Now;
            await repo.SaveAll();
        }
    }
}
