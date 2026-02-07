namespace Web.Middlewares
{
    public abstract class BaseMiddleware
    {
        protected RequestDelegate _next;
        public BaseMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public abstract Task Invoke(HttpContext context);
    }
}
