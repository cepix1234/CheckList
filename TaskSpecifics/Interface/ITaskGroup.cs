using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CheckList.TaskSpecifics.Class;

namespace CheckList.TaskSpecifics.Interface
{
    interface ITaskGroup
    {
        List<Task> tasks
        {
            get;
            set;
        }
    }
}
