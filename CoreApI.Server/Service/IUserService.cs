using CoreApI.Server.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreApI.Server.Service
{
    public interface IUserService
    {
        public bool GetUser(UserDTO userDto);
        public bool register([FromForm] RegsiterDTO regDto);
        public bool regist([FromForm] RegsiterDTO user);

    }
}
