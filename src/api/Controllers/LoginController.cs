using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using api.Models;


namespace api.Controllers
{
  [Route("api/login")]
  public class LoginController : Controller
  {

    [HttpPost()]
    public ResponseMessage Post([FromBody]User user)
    {

      if (string.IsNullOrEmpty(user.Username) || string.IsNullOrEmpty(user.Password))
      {
        return new ResponseMessage()
        {
          Status = "ERROR",
          Message = "Username and Password are required."
        };
      }

      User expected_user = new User()
      {
        Id = 1,
        Username = "ploy",
        Displayname = "พลอย"
      };

      return new ResponseMessage()
      {
        Status = "OK",
        Results = expected_user
      };



    }
  }
}
