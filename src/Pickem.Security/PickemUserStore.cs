using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace Pickem.Security
{
    public class PickemUserStore<TUser>: IUserStore<TUser> where TUser: IUser
    {
        public void Dispose()
        {
        }

        public Task CreateAsync(TUser user)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(TUser user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(TUser user)
        {
            throw new NotImplementedException();
        }

        public Task<TUser> FindByIdAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<TUser> FindByNameAsync(string userName)
        {
            throw new NotImplementedException();
        }
    }
}
