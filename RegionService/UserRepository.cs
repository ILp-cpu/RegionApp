using RegionService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RegionService
{
    public class UserService : IUserService
    {
        private readonly RegionContext.RegionDBContext _rcxt;

        public UserService(RegionContext.RegionDBContext rcxt)
        {
            _rcxt = rcxt;
        }

        //public List<User> GetUsers()
        //{
          //  return _rcxt.Users.ToList();
        //}
    }
}
