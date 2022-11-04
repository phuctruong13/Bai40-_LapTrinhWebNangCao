using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using blogAPI.Data;
using Microsoft.AspNetCore.Mvc;

namespace blogAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        private readonly AppDbContext _context;
        public TestController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetData()
        {
            return Ok(new
            {
                status = "ok",
                data = "Success"
            });
        }
        [HttpPost]
        public IActionResult PostData()
        {
            _context.Users.Add(new Models.User()
            {
                DisplayName = "Hiệp Đặng",
                Email = "hiepdang31032001@gmail.com",
                Phone = "*****",
                Address = "bien hoa",
                DateOfBirth = DateTime.UtcNow,

            });
            _context.SaveChanges();
            return Ok(User);

        }
    }
}