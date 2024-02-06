using dotnetEncryptionSample.Services;
using Microsoft.AspNetCore.Mvc;

namespace dotnetEncryptionSample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EncryptionController : ControllerBase
    {
        private EncryptionService _encryptionService;

        public EncryptionController() 
        {
            _encryptionService = new EncryptionService();
        }

        [HttpGet]
        public (string, string, string) Index()
        {
            var encrypt = _encryptionService.EncryptAes("Hello World.");
            return encrypt;
        }
    }
}
