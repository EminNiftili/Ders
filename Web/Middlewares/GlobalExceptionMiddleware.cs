
using System.Text;

namespace Web.Middlewares
{
    public class GlobalExceptionMiddleware : BaseMiddleware
    {
        public GlobalExceptionMiddleware(RequestDelegate next) : base(next)
        {
        }

        public override async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch(Exception e)
            {
                context.Response.StatusCode = 200;
                await context.Response.WriteAsync("Server is full now please try later");
            }
        }
    }
}
