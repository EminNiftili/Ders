using Microsoft.AspNetCore.Mvc.Filters;

namespace Web.Filters
{
    public class AgeFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if(context.HttpContext.Request.Headers.TryGetValue("Age", out var ageString) 
                && int.TryParse(ageString, out var age))
            {
                if(age < 18)
                {
                    context.Result = new Microsoft.AspNetCore.Mvc.ContentResult
                    {
                        StatusCode = 403,
                        Content = "Access denied. You must be at least 18 years old."
                    };
                }
            }
            else
            {
                context.Result = new Microsoft.AspNetCore.Mvc.ContentResult
                {
                    StatusCode = 404,
                    Content = "Does not get age data"
                };
            }
        }
    }
}
