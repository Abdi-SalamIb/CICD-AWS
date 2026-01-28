using Microsoft.AspNetCore.Mvc;
using EncryptionAPI.Services;

namespace EncryptionAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CryptoController : ControllerBase
    {
        private readonly ICryptoService _cryptoService;

        public CryptoController(ICryptoService cryptoService)
        {
            _cryptoService = cryptoService;
        }

        [HttpPost("encrypt")]
        public ActionResult<CryptoResponse> Encrypt([FromBody] CryptoRequest request)
        {
            if (string.IsNullOrEmpty(request.Text))
            {
                return BadRequest("Texten får inte vara tom");
            }

            var encryptedText = _cryptoService.Encrypt(request.Text, request.Shift);

            return Ok(new CryptoResponse
            {
                OriginalText = request.Text,
                ResultText = encryptedText,
                Shift = request.Shift,
                Operation = "Kryptering"
            });
        }

        [HttpPost("decrypt")]
        public ActionResult<CryptoResponse> Decrypt([FromBody] CryptoRequest request)
        {
            if (string.IsNullOrEmpty(request.Text))
            {
                return BadRequest("Texten får inte vara tom");
            }

            var decryptedText = _cryptoService.Decrypt(request.Text, request.Shift);

            return Ok(new CryptoResponse
            {
                OriginalText = request.Text,
                ResultText = decryptedText,
                Shift = request.Shift,
                Operation = "Dekryptering"
            });
        }
    }

    public class CryptoRequest
    {
        public string Text { get; set; } = string.Empty;
        public int Shift { get; set; } = 3;
    }

    public class CryptoResponse
    {
        public string OriginalText { get; set; } = string.Empty;
        public string ResultText { get; set; } = string.Empty;
        public int Shift { get; set; }
        public string Operation { get; set; } = string.Empty;
    }
}
