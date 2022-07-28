using Microsoft.AspNetCore.Server.HttpSys;

namespace Samples.Httpsys.Attributes
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

                    webBuilder.UseHttpSys(options =>
                    {
                        options.AllowSynchronousIO = false;
                        options.Authentication.Schemes = AuthenticationSchemes.None;
                        options.Authentication.AllowAnonymous = true;
                        options.MaxConnections = null;
                        options.MaxRequestBodySize = 30000000;
                        options.UrlPrefixes.Add("http://localhost:5005/attributes");
                    });

                    webBuilder.UseStartup<Startup>();
                });
    }
}