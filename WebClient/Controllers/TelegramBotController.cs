using Microsoft.AspNetCore.Mvc;
using WebClient.Entities;
using WebClient.Modules;

namespace WebClient.Controllers {
    [ApiController]
    [Route("api/message")]
    public class TelegramBotController : ControllerBase {
        private readonly UsersContext _usersContext;
        public TelegramBotController(UsersContext usersContext) {
            _usersContext = usersContext;
        }

        [HttpPost]
        [Route("Update")]
        public IActionResult Update(string text) {
            _usersContext.Add(new BotUser { Name = text });
            _usersContext.SaveChanges();
            return Ok();
        }
        [HttpGet]
        [Route("GetDB")]
        public string Get() {
            return _usersContext.Users.OrderBy(n => n.Name).First().Name;
        }
    }
}