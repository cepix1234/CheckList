using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckList.DataProviders.Interfaces;
using CheckList.TaskSpecifics;
using CheckList.TaskSpecifics.Class;
using CheckList.TaskSpecifics.Interface;
using Newtonsoft.Json;

namespace CheckList.DataProviders.Services
{
    class JsonProvider : IDataProviderBase
    {
        public IDataProividerResultTasksBase GetData(IDataSourceConfiguration configuration)
        {

            IDataProividerResultTasksBase result = new DataProviderResultTasks();
            IsConfigurationValid(configuration);

            try
            {
                using (StreamReader r = new StreamReader(configuration.File.File))
                {
                    string json = r.ReadToEnd();
                    result.data = JsonConvert.DeserializeObject<TaskGroup>(json);
                }
            }
            catch (Exception error)
            {
                result.sucess = false;
                result.error = error.Message;
                return result;
            }

            result.sucess = true;

            return result;
        }

        public IDataProividerResultTasksBase SetData(IDataSourceConfiguration configuration, TaskSpecifics.Class.Task data, ITaskGroup tasks)
        {
            IDataProividerResultTasksBase result = new DataProviderResultTasks();
            if (!configuration.IsValid())
            {
                result.sucess = false;
                return result;
            }

            try
            {
                if (configuration.AddTask)
                {
                    result = AddTaskToTasks(data, tasks);
                }

                if (configuration.DeliteTask)
                {
                    result = RemoveTaskFromTasks(data, tasks);
                }

                if (configuration.SetTask)
                {
                    result = SetTaskStatusInTasks(data, tasks);
                }


                result = WriteTasksToFile(configuration, result.data);
                result.sucess = true;
            }
            catch (Exception error)
            {
                result.sucess = false;
                result.error = error.Message;
                return result;
            }
            return result;
        }
        private IDataProividerResultTasksBase AddTaskToTasks(TaskSpecifics.Class.Task data, ITaskGroup tasks)
        {
            IDataProividerResultTasksBase result = new DataProviderResultTasks();
            ITaskGroup tasksCoppy = tasks.Clone();
            try
            {
                tasksCoppy.AddTask(data);
                result.data = tasksCoppy;
                result.sucess = true;
            }
            catch (Exception error)
            {
                result.sucess = false;
                result.error = error.Message;
            }
            return result;
        }

        private IDataProividerResultTasksBase RemoveTaskFromTasks(TaskSpecifics.Class.Task data, ITaskGroup tasks)
        {
            IDataProividerResultTasksBase result = new DataProviderResultTasks();
            ITaskGroup tasksCoppy = tasks.Clone();
            try
            {
                tasksCoppy.RemoveTask(data);
                result.data = tasksCoppy;
                result.sucess = true;
            }
            catch (Exception error)
            {
                result.sucess = false;
                result.error = error.Message;
            }
            return result;
        }

        private IDataProividerResultTasksBase SetTaskStatusInTasks(TaskSpecifics.Class.Task data, ITaskGroup tasks)
        {
            IDataProividerResultTasksBase result = new DataProviderResultTasks();
            ITaskGroup tasksCoppy = tasks.Clone();
            try
            {
                tasksCoppy.SetTask(data);
                result.data = tasksCoppy;
                result.sucess = true;
            }
            catch (Exception error)
            {
                result.sucess = false;
                result.error = error.Message;
            }
            return result;
        }

        private IDataProividerResultTasksBase WriteTasksToFile(IDataSourceConfiguration configuration, ITaskGroup tasks)
        {
            IDataProividerResultTasksBase result = new DataProviderResultTasks();
            IsConfigurationValid(configuration);
            try
            {
                using (StreamWriter r = new StreamWriter(configuration.File.File))
                {
                    string data = JsonConvert.SerializeObject(tasks);
                    r.Write(data);
                }
                result.data = tasks;
            }
            catch (Exception error)
            {
                result.sucess = false;
                result.error = error.Message;
            }
            return result;
        }

        private void IsConfigurationValid(IDataSourceConfiguration configuration)
        {
            if (!configuration.IsValid())
            {
                throw new Exception("Configuration is not valid for data provider");
            }

            if (configuration.File.File == "undefined" || configuration.File == null)
            {
                throw new Exception("Configuration file is not defined");
            }
        }
    }
}
