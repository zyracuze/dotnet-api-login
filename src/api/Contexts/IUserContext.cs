using System;
using api.Models;

namespace api.Contexts
{
    public interface IUserContext
    {
       User FindUserByUsernameAndPassword(string username, string hashPassword);
    }
}