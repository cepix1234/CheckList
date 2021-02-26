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

        protected TaskGroup()
        {
        }

        protected TaskGroup(TaskGroup old)
        {
            this.tasks = old.tasks;
        }

        public List<Task> tasks { 
            get;
            set;
        }

        public void SetData(ITaskGroup data)
        {
            if(data != null)
            this.tasks = data.tasks;
        }

        public ITaskGroup Clone()
        {
            return new TaskGroup(this);
        }

        public void AddTask(Task task)
        {
            // Check if task already exists.
            bool found = false;
            foreach (Task tableTask in tasks)
            {
                if(tableTask.title == task.title)
                {
                    found = true;
                    break;
                }
            }
            if(found)
            {
                throw (new Exception("Task already exists"));
            }
            this.tasks.Add(task);
        }

        public void RemoveTask(Task task)
        {
            int index = 0;
            Boolean found = false;
            foreach (Task tableTask in tasks)
            {
                if (tableTask.title == task.title)
                {
                    found = true;
                    break;
                }
                index++;
            }
            if(found)
            {
                this.tasks.RemoveAt(index);
            }
        }

        public void SetTask(Task task)
        {
            foreach (Task tableTask in this.tasks)
            {
                if (tableTask.title == task.title)
                {
                    tableTask.finished = task.finished;
                    break;
                }
            }
        }
    }
}
