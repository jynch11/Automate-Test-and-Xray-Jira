using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using BoDi;
using Ductus.FluentDocker.Builders;
using Ductus.FluentDocker.Services;
using Microsoft.Extensions.Configuration;
using TechTalk.SpecFlow.Configuration;

namespace Ticketing.Specs.Hooks
{
    [Binding]
    public class DockerControllerHooks
    {

        private static ICompositeService _compositeService;
        private IObjectContainer _objectContainer;

        public DockerControllerHooks(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        [BeforeTestRun]
        public static void DockerComposeUp()
        {
            var config = LoadConfiguration();
            var dockerComposeFileName = config["DockerComposeFileName"];
            var dockerComposePath = GetDockerComposeLocation(dockerComposeFileName);
            var DockerComposeOverrideFileName = config["DockerComposeOverrideFileName"];
            var dockerComposeOverridePath = GetDockerComposeLocation(DockerComposeOverrideFileName);
            var confirmationUrl = config["Ticketing.API:BaseAddress"];

            _compositeService = new Builder()
                .UseContainer()
                .UseCompose()
                .FromFile(dockerComposePath)
                .FromFile(dockerComposeOverridePath)
                .RemoveOrphans()
                .WaitForHttp("ticketing.api", $"{confirmationUrl}/api/v1/Ticketing",
                        continuation: (response, _) => response.Code != HttpStatusCode.OK ? 2000 : 0)
                .Build().Start();
        }

        [AfterTestRun]
        public static void DockerComposeDown()
        {
            _compositeService.Stop();
            _compositeService.Dispose();

        }

        [BeforeScenario]
        public void AddHttpClient()
        {
            var config = LoadConfiguration();
            var HttpClient = new HttpClient
            {
                BaseAddress = new Uri(config["Ticketing.API:BaseAddress"])
            };
            _objectContainer.RegisterInstanceAs(HttpClient);
        }

        private static IConfiguration LoadConfiguration()
        {
            return new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
        }

        private static string GetDockerComposeLocation(string dockerComposeFileName)
        {
            var directory = Directory.GetCurrentDirectory();
            while (!Directory.EnumerateFiles(directory, "*.yml").Any(s => s.EndsWith(dockerComposeFileName)))
            {
                directory = directory.Substring(0, directory.LastIndexOf(Path.DirectorySeparatorChar));
            }

            return Path.Combine(directory, dockerComposeFileName);

        }

    }
}
