using CheckList.TaskSpecifics.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckList.FollowingDays.Interfaces;

namespace CheckList.DataProviders.Interfaces
{
    public interface IDataProividerResultDayBase : IDataProviderResultBase
    {
        IDayFollowed data
        {
            get;
            set;
        }
    }
}
