using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CheckList.FollowingDays.Interfaces;
using CheckList.TaskSpecifics.Interface;

namespace CheckList.DataProviders.Interfaces
{
    public interface IDataProviderBase
    {
        IDataProviderResultBase GetData(IDataSourceConfiguration configuration);

        IDataProviderResultBase SetData(IDataSourceConfiguration configuration, ITaskGroup tasks);

        IDataProviderResultBase SetData(IDataSourceConfiguration configuration, IDayFollowed tasks);
    }
}
