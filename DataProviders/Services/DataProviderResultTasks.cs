using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckList.DataProviders.Interfaces;
using CheckList.TaskSpecifics.Interface;

namespace CheckList.DataProviders.Services
{
    class DataProviderResultTasks : IDataProividerResultTasksBase
    {
        public ITaskGroup data { 
            get;
            set;
        }
        public bool sucess
        {
            get;
            set;
        }
        public string error
        {
            get;
            set;
        }
    }
}
