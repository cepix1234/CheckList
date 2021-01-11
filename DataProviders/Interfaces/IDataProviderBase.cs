using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CheckList.TaskSpecifics.Interface;

namespace CheckList.DataProviders.Interfaces
{
    interface IDataProviderBase
    {
        IDataProividerResultTasksBase GetData(IDataSourceFileConfiguration configuration);

        IDataProviderResultBase SetData(IDataSourceFileConfiguration configuration, ITaskBase data);
    }
}
