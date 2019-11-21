using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace FaceDetector
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder
#if DEBUG
                        .UseStartup<Startup>();
                    // .UseUrls("http://192.168.0.103:5500");
#else
                        .UseStartup<Startup>();
#endif
                });
    }
}
