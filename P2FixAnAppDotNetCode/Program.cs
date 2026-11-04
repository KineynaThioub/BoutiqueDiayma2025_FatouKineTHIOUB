using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Localization;

// Indique au système de localisation l'espace de noms racine des ressources (.resx)
[assembly: RootNamespace("P2FixAnAppDotNetCode")]

namespace P2FixAnAppDotNetCode
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
