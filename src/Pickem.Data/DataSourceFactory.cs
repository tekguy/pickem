using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pickem.Data
{
    public class DataSourceFactory:IDataSourceFactory
    {
        public PickemContext GetDbContext()
        {
            return new PickemContext();
        }
    }
}
