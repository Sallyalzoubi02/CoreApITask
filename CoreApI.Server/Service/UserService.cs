using CoreApI.Server.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreApI.Server.Service
{
    public class UserService : IUserService
    {
        private readonly MyDbContext _db;

        public UserService(MyDbContext db)
        {
            _db = db;
        }

        [HttpPost]
        public bool GetUser(UserDTO userDto)
        {
            var user = _db.Users.FirstOrDefault(x => userDto.Email == x.Email &&  userDto.Password == x.Password );

            if (user == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool register([FromForm] RegsiterDTO regDto)
        {
            var reg = _db.Users.FirstOrDefault(x => x.Email == regDto.Email);

            if (reg == null)
            {
                User user = new User();
                user.Email = regDto.Email;
                user.Password = regDto.Password;
                user.CreatedAt = DateTime.Now;
                user.Name = regDto.Name;
                _db.Users.Add(user);
                _db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool regist([FromForm] RegsiterDTO user)
        {
            var exist = _db.Users.FirstOrDefault(x => x.Email == user.Email);

            if(exist != null)
            {
                return false;
            }

            var NewUser = new User();
            NewUser.Email = user.Email;
            NewUser.Name = user.Name;
            NewUser.Password = user.Password;

            _db.Users.Add(NewUser);
            _db.SaveChanges();
            return true;

        }


    }
}
