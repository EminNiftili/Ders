using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace Web.Filters
{
    public class PerformanceFilter : IActionFilter
    {
        private Stopwatch stopwatch = new Stopwatch();
        public void OnActionExecuted(ActionExecutedContext context)
        {
            stopwatch.Stop();
            var elapsed = stopwatch.ElapsedMilliseconds;
            if (context.HttpContext.Response.Headers.ContainsKey("Performance"))
            {
                context.HttpContext.Response.Headers["Performance"] = elapsed.ToString();
            }
            else
            {
                context.HttpContext.Response.Headers.Add("Performance", elapsed.ToString());
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            stopwatch.Start();
        }
    }
}
