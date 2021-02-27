using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace EnvironmentConfiguration.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigController : ControllerBase
    {
        private readonly IOptions<AppConfig> appConfig;

        public ConfigController(IOptions<AppConfig> appConfig)
        {
            this.appConfig = appConfig;
        }

        [HttpGet]
        public string GetEnvironment()
        {
            return appConfig.Value.Environment;
        }
    }
}
