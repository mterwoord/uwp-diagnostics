using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Owin.Hosting;
using Owin;

namespace UwpDiagnosticsServer
{
    class Program
    {
        static void Main(string[] args)
        {
            var xUrl = "http://+:60864/";
            using (WebApp.Start(xUrl, OnStartup))
            {
                Console.WriteLine("Running at {0}", xUrl);
                Console.WriteLine("Press enter to exit.");
                Console.ReadLine();
            }
        }

        private static void OnStartup(IAppBuilder app)
        {
            var xConfig = new HttpConfiguration();
            xConfig.Routes.MapHttpRoute("Default", "{controller}/{action}", new
                                                                          {
                                                                              controller = "Home",
                action = "Index"
                                                                          });
            app.UseWebApi(xConfig);

        }
    }
}
