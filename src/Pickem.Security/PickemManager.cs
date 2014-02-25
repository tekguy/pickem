using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Pickem.Model;

namespace Pickem.Security
{
    public class PickemUserManager<TUser> : UserManager<TUser> where TUser : IUser
    {
        public PickemUserManager(PickemUserStore<TUser> store) : base(store)
        {
        }

        public override Task<TUser> FindAsync(string userName, string password)
        {
            return base.FindAsync(userName, password);
        }
    }
}
