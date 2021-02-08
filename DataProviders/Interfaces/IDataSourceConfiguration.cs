using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckList.DataProviders.Services;
using CheckList.TaskSpecifics.Class;

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

        TaskSpecifics.Class.Task Task
        {
            get;
            set;
        }

    }
}
