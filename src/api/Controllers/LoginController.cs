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
            if (authenticationService.IsUsernameOrPasswordEmpty(user.Username, user.Password))
            {
                return GetErrorMessage("ERROR", "Username and Password are required.");
            }

            try
            {
                User resultUser = authenticationService.Login(user.Username, user.Password);
                return GetOkMessage("OK", resultUser);
            }
            catch (UserNotFoundException ex)
            {
                return GetErrorMessage("ERROR", ex.Message);
            }

        }

        private ResponseMessage GetErrorMessage(string status, string message)
        {
            return GenerateResponseMessage(status, message, null);
        }
        private ResponseMessage GetOkMessage(string status, User user)
        {
            return GenerateResponseMessage(status, null, user);
        }
        private ResponseMessage GenerateResponseMessage(string status, string message, User user)
        {
            return new ResponseMessage()
            {
                Status = status,
                Message = message,
                Results = user
            };
        }
    }
}
