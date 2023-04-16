using Homework2.Data.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Homework2.BockAttribute
{
    public class AccountIdFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var httpContext = context.HttpContext;
            var accountId = httpContext.Session.GetInt32("AccountId");

            if (!accountId.HasValue)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status401Unauthorized);
                return;
            }

            // Set the accountId in the route data so it can be accessed by the action
            context.RouteData.Values.Add("AccountId", accountId.Value);

            base.OnActionExecuting(context);
        }
    }
}
