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
    private readonly IAuthenticationService authenticationService;

    public LoginController(IAuthenticationService service)
    {
      authenticationService = service;
    }

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

      try
      {
        User expected_user = authenticationService.Login(user.Username, user.Password);

        return new ResponseMessage()
        {
          Status = "OK",
          Results = expected_user
        };
      }
      catch (UserNotFoundException ex)
      {

        return new ResponseMessage()
        {
          Status = "ERROR",
          Message = ex.Message
        };
      }

    }
  }
}
