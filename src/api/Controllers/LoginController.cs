using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using api.Models;
using api.Services;
using api.Exceptions;

namespace api.Controllers
{
  [Route("api/login")]
  public class LoginController : Controller
  {
    private readonly AuthenticationService authenticationService;

    public LoginController(AuthenticationService service)
    {
      authenticationService = service;
    }

    [HttpPost()]
    public ResponseMessage Post([FromBody]User user)
    {

      if (UsernameOrPasswordIsEmpty(user.Username, user.Password))
      {
        return GenerateResponseMessage("ERROR", "Username and Password are required.");
      }

      try
      {
        User resultUser = authenticationService.Login(user.Username, user.Password);
        return GenerateResponseMessage("OK", resultUser);
      }
      catch (UserNotFoundException ex)
      {
        return GenerateResponseMessage("ERROR", ex.Message);
      }

    }

    private bool UsernameOrPasswordIsEmpty(string username, string password)
    {
      return string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password);
    }

    private ResponseMessage GenerateResponseMessage(string status, string message)
    {
      return new ResponseMessage()
        {
          Status = status ,
          Message = message
        };
    }
    private ResponseMessage GenerateResponseMessage(string status, User user)
    {
      return new ResponseMessage()
        {
          Status = status ,
          Results = user 
        };
    }
  }
}
