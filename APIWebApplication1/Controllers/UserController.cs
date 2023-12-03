using APIWebApplication1.Database;
using APIWebApplication1.Model.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIWebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private static FakeDatabase database = new FakeDatabase();


        [HttpGet]
        public IActionResult GetUser(int id)
        {
            var user = database.Users.FirstOrDefault(x => x.IdUser == id);
            if (user == null) {
                return NotFound();
            } else { return Ok(user); }
        }

        [HttpDelete]
        public IActionResult DeleteUser(int id)
        {
            var user = database.Users.FirstOrDefault(x => x.IdUser == id);
            if (user == null)
            {
                return NotFound();
            }
            else {
                database.Users.Remove(user);

                return Ok();
            }
        }

        [HttpPost]
        public IActionResult AddNewUser([FromBody] AddUserRequest user)
        {
            database.AddUser(new Database.User { IdUser = 0, Name =user.Name, Password = user.Password, Surname= user.Surname , UserName = user.UserName });

            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateUser([FromBody] UpdateUserRequest user)
        {
            var userCurrent = database.Users.FirstOrDefault(x => x.IdUser == user.Id);
            if (userCurrent == null)
            {
                return NotFound();
            }
            else
            {
                userCurrent.Name = user.Name;
                userCurrent.UserName = user.UserName;
                userCurrent.Surname = user.Surname;
                userCurrent.Password = user.Password;

                return Ok();
            }
        }

        [HttpGet("all")]
        public IActionResult AllUsers()
        {
            return Ok(database.Users);
        }
    }
}
