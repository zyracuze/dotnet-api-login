using System;

namespace api.Models
{
    public interface IUserContext
    {
       User FindUserByUsernameAndPassword(string username, string hashPassword);
    }
}