using Microsoft.AspNetCore.Mvc;

namespace MyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InfoController : ControllerBase
    {
        // GET: api/info/home
        [HttpGet("home")]
        public IActionResult GetHome()
        {
            return Ok(new
            {
                title = "Chào mừng đến với MyApi Shop",
                subtitle = "Dự án mẫu ASP.NET Core Web API thuần + Frontend Bootstrap",
                highlights = new[]
                {
                    "Nhanh chóng - xây dựng trên ASP.NET Core hiệu năng cao",
                    "Bảo mật - đăng nhập/đăng ký dùng JWT",
                    "Mở rộng - API REST chuẩn, dễ tích hợp mobile app hoặc frontend khác"
                }
            });
        }

        // GET: api/info/about
        [HttpGet("about")]
        public IActionResult GetAbout()
        {
            return Ok(new
            {
                title = "Giới thiệu về chúng tôi",
                content = "MyApi là một dự án mẫu xây dựng bằng ASP.NET Core Web API thuần (không dùng MVC View). " +
                           "Toàn bộ dữ liệu được trả về dưới dạng JSON, và một frontend riêng (HTML + Bootstrap) sẽ " +
                           "gọi các API này để hiển thị giao diện cho người dùng.",
                technologies = new[]
                {
                    "ASP.NET Core 8 Web API",
                    "Entity Framework Core + SQLite",
                    "ASP.NET Core Identity + JWT",
                    "Bootstrap 5 (frontend)"
                }
            });
        }
    }
}
