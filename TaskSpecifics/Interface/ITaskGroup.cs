using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CheckList.TaskSpecifics.Class;

namespace CheckList.TaskSpecifics.Interface
{
    public interface ITaskGroup
    {
        List<Task> tasks
        {
            get;
            set;
        }

        void SetData(ITaskGroup data);

        ITaskGroup Clone();

        void AddTask(Task task);

        void RemoveTask(Task task);

        void SetTask(Task task);
    }
}
