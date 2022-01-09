using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlankUpLetter
{
    public class Startup
    {
        IWebHostEnvironment _env;
        public Startup(IWebHostEnvironment env)
        {
            _env = env;
        }
        public void ConfigureServices(IServiceCollection services)
        {
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<GetWordsMiddleware>("12345678");
            app.Map("/words", GetWords);
            app.Map("/add", Add);
            app.Map("/delete", Delete);
            app.Map("/addmany", AddMany);

            app.Run(async (context) =>
            {
                context.Response.ContentType = AddReg();
                await context.Response.WriteAsync("Замена первой буквы на большую");
            });
        }
        private static string AddReg()
        {
            return "text/html; charset=utf-8";
        }
        private static void GetWords(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                context.Response.ContentType = AddReg();
                await context.Response.WriteAsync("Список слов в базе");
            });
        }
        private static void Add(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                context.Response.ContentType = AddReg();
                await context.Response.WriteAsync("Добавить слово в базу");
            });
        }
        private static void Delete(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                context.Response.ContentType = AddReg();
                await context.Response.WriteAsync("Удалить слово из базы");
            });
        }
        private static void AddMany(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                context.Response.ContentType = AddReg();
                await context.Response.WriteAsync("Добавить найденные слова в базу");
            });
        }
    }
}
