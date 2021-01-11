using CheckList.TaskSpecifics.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckList.DataProviders.Interfaces
{
    interface IDataProividerResultTasksBase : IDataProviderResultBase
    {
        ITaskGroup data
        {
            get;
            set;
        }
    }
}
