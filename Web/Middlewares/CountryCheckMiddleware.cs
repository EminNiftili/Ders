namespace Web.Middlewares
{
    public class CountryCheckMiddleware : BaseMiddleware
    {
        public CountryCheckMiddleware(RequestDelegate next) : base(next)
        {
        }
        public override async Task Invoke(HttpContext context)
        {
            if(context.Request.Headers.TryGetValue("Country", out var country))
            {
                if(country != "azerbaijan")
                {
                    context.Response.StatusCode = 403;
                    await context.Response.WriteAsync("Access denied from your country.");
                    return;
                }
            }
            else
            {
                context.Response.StatusCode = 404;
                await context.Response.WriteAsync("Country does not found.");
                return;
            }
            var ipAdres = context.Connection.RemoteIpAddress?.ToString();

            await _next(context);
        }
    }
}
