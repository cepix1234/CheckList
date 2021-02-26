using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckList.DataProviders.Services;
using CLTask = CheckList.TaskSpecifics.Class.Task;

namespace CheckList.DataProviders.Interfaces
{
    public interface IDataSourceConfiguration
    {
        Boolean AddTask
        {
            get;
            set;
        }

        Boolean DeliteTask 
        {
            get;
            set;
        }

        Boolean SetTask
        {
            get;
            set;
        }

        Boolean GetTaskByTitle
        {
            get;
            set;
        }

        Boolean GetAllTasks
        {
            get;
            set;
        }

        Boolean GetFinishedTasks
        {
            get;
            set;
        }

        Boolean GetUnfinishedTasks
        {
            get;
            set;
        }

        Boolean IsValid();

        DataSourceFileConfiguration File
        {
            get;
            set;
        }

        CLTask Task
        {
            get;
            set;
        }

        void Clear();

    }
}
