using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MockAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MockAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : BaseApiController
    {
        private readonly ILogger<UserController> _logger;

        [HttpGet]
        public ResponseWrapper Get()
        {
            var rng = new Random();
            var result = Enumerable.Range(1, 5).Select(index => new User
            {
                Id = index,
                Name = "Pham Truong An",
                Age = rng.Next(20, 55),
            })
            .ToArray();
            return ok_get(result);
        }
        [HttpPost]
        public ResponseWrapper Post(User usr)
        {
            return ok_create(usr);
        }
        [HttpPut]
        public ResponseWrapper Put([FromQuery] int id, User modUsr)
        {
            if (modUsr.Id == 0)
                return error(System.Net.HttpStatusCode.BadRequest, "Can't found id");
            if (id > 0)
                return ok_update();
            else
                return error(System.Net.HttpStatusCode.BadRequest, "Can't found id");
            
        }
        [HttpDelete]
        public ResponseWrapper Delete([FromQuery] int id)
        {
            if (id > 0)
                return ok_delete();
            else
                return error(System.Net.HttpStatusCode.BadRequest, "Can't found id");
        }
    }
}
