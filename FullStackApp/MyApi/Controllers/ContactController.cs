using Microsoft.AspNetCore.Mvc;
using MyApi.Dtos;

namespace MyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly ILogger<ContactController> _logger;

        public ContactController(ILogger<ContactController> logger)
        {
            _logger = logger;
        }

        // POST: api/contact
        [HttpPost]
        public IActionResult Submit(ContactDto dto)
        {
            // Ở đây có thể lưu vào DB hoặc gửi email thật, hiện tại chỉ ghi log và trả về thành công
            _logger.LogInformation("Liên hệ mới từ {Name} ({Email}): {Message}", dto.Name, dto.Email, dto.Message);
            return Ok(new { message = "Cảm ơn bạn đã liên hệ! Chúng tôi sẽ phản hồi sớm nhất." });
        }
    }
}
