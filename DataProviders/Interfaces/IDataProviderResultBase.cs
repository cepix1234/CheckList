using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckList.DataProviders.Interfaces
{
    public interface IDataProviderResultBase
    {
        Boolean sucess
        {
            get;
            set;
        }

        String error
        {
            get;
            set;
        }
    }
}
