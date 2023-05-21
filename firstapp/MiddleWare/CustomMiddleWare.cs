namespace MyFirstApp.MiddleWare
{
    public class CustomMiddleWare : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("Hi iam yuvaraj\n");
            await next(context);
            await context.Response.WriteAsync("Hi iam karpagam\n");
        }
    }
}
