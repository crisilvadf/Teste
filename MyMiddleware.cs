using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace hosting
{
    public class MyMiddleware
    {
        private RequestDelegate _next;

        public MyMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context){
            //gerenciar o tempo da minha requisição
            //o que fizer antes do middleware eu trabalho com minha request            
            //Request
            var start = DateTime.Now;

            //middleware
            await _next(context);

            //o que fizer depois do middleware eu trabalho com minha response
            //Response
            var finish = DateTime.Now;

            var diff = finish.Subtract(start);

            //A utilziação do sinal '$' é o mesmo do que usar o sina '+' para concatenar
            await context.Response.WriteAsync($"The time was {diff.Milliseconds}");

        }
    }
}