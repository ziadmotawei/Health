namespace Health
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _requestDelegate;
        public RequestLoggingMiddleware(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            Console.WriteLine($"Request: {context.Request.Method} {context.Request.Path}");
            await _requestDelegate(context);  
        }
    }
}
