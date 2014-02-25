using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace Pickem.Model.Authentication
{
    public class UserManager<TUser> : IDisposable where TUser : IUser
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        
    }
}
