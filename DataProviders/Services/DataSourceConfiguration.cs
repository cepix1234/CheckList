using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckList.DataProviders.Interfaces;
using CLTask = CheckList.TaskSpecifics.Class.Task;

namespace CheckList.DataProviders.Services
{
    class DataSourceConfiguration : IDataSourceConfiguration
    {

        public DataSourceConfiguration(DataSourceFileConfiguration File)
        {
            this.File = File;
        }

        public DataSourceConfiguration(DataSourceFileConfiguration File, CLTask Task)
        {
            this.File = File;
            this.Task = Task;
        }

        public bool AddTask
        {
            get;
            set;
        }
        public bool DeliteTask
        {
            get;
            set;
        }
        public bool SetTask
        {
            get;
            set;
        }
        public bool GetTaskByTitle
        {
            get;
            set;
        }

        public bool GetAllTasks
        {
            get;
            set;
        }

        public bool GetFinishedTasks
        {
            get;
            set;
        }

        public bool GetUnfinishedTasks
        {
            get;
            set;
        }

        public bool IsValid()
        {
            if (!(this.AddTask ^ this.DeliteTask ^ this.SetTask ^ this.GetTaskByTitle ^ this.GetAllTasks ^ this.GetFinishedTasks ^ this.GetUnfinishedTasks))
            {
                return false;
            }

            if((this.AddTask || this.DeliteTask || this.SetTask || this.GetTaskByTitle) && this.Task == null)
            {
                return false;
            }


            return true;
        }
        public DataSourceFileConfiguration File
        {
            get;
            set;
        }

        public CLTask Task
        {
            get;
            set;
        }

        public void Clear()
        {
            this.AddTask = false;
            this.DeliteTask = false;
            this.SetTask = false;
            this.GetTaskByTitle = false;
            this.GetAllTasks = false;
            this.GetFinishedTasks = false;
            this.GetUnfinishedTasks = false;
        }
    }
}
