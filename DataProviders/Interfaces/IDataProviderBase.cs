using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CheckList.TaskSpecifics.Interface;

namespace CheckList.DataProviders.Interfaces
{
    public interface IDataProviderBase
    {
        IDataProividerResultTasksBase GetData(IDataSourceConfiguration configuration);

        IDataProividerResultTasksBase SetData(IDataSourceConfiguration configuration, ITaskGroup tasks);
    }
}
