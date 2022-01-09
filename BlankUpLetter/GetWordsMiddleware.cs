using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace BlankUpLetter
{
    public class GetWordsMiddleware
    {
        private readonly RequestDelegate _next;
        private string pattern;

        public GetWordsMiddleware(RequestDelegate next, string pattern)
        {
            this._next = next;
            this.pattern = pattern;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            var check = context.Request.Query["words"];

            if (check == pattern)
            {
                context.Response.StatusCode = 403;
                context.Response.ContentType = "text/html; charset=utf-8";
                await context.Response.WriteAsync("Неверный ввод");
            }
            else
            {
                await _next.Invoke(context);
            }
        }
    }
}
