using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Pickem.Data
{
    public interface IDataSourceFactory
    {
        PickemContext GetDbContext();
    }
}
