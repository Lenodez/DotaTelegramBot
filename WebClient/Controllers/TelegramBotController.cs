using Microsoft.AspNetCore.Mvc;
using WebClient.Entities;
using WebClient.Modules;

namespace WebClient.Controllers {
    [ApiController]
    [Route("api/message")]
    public class TelegramBotController : ControllerBase {
        private readonly DataBaseModule _dataBaseModule;
        public TelegramBotController(DataBaseModule dataBaseModule) {
            _dataBaseModule = dataBaseModule;
        }

        [HttpPost]
        [Route("Update")]
        public IActionResult Update(string text) {
            _dataBaseModule.usersContext.Add(new BotUser { Name = text });
            _dataBaseModule.usersContext.SaveChanges();
            return Ok();
        }
        [HttpGet]
        [Route("GetDB")]
        public string Get() {
            return _dataBaseModule.usersContext.Users.OrderBy(n => n.Name).First().Name;
        }
    }
}