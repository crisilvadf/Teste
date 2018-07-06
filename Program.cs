using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace hosting
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                //utilizado para iniciar o conteúdo do arquivo statup.cs
                .UseStartup<Startup>()
                //utilizado para acessar arquivos na raiz do documento
                .UseContentRoot(Directory.GetCurrentDirectory())
                .Build();
            host.Run();
        }      
    }
}
