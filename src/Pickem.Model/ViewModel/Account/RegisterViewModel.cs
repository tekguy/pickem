using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pickem.Model.ViewModel.Account
{
    public class RegisterViewModel:BaseViewModel
    {
        public UserAccount UserAccount { get { return new UserAccount();} }
    }
}
