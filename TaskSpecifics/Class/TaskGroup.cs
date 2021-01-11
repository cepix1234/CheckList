using CheckList.TaskSpecifics.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckList.TaskSpecifics.Class
{
    class TaskGroup : ITaskGroup
    {
        public List<Task> tasks { 
            get;
            set;
        }
    }
}
