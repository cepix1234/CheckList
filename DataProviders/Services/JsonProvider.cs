using System;
using System.IO;
using CheckList.DataProviders.Interfaces;
using CheckList.TaskSpecifics.Class;
using CLTask = CheckList.TaskSpecifics.Class.Task;
using CheckList.TaskSpecifics.Interface;
using Newtonsoft.Json;
using CheckList.FollowingDays.Class;
using CheckList.FollowingDays.Interfaces;

namespace CheckList.DataProviders.Services
{
    class JsonProvider : IDataProviderBase
    {
        public IDataProviderResultBase GetData(IDataSourceConfiguration configuration)
        {
            if(configuration.getDayFollowd)
            {
                IDataProividerResultDayBase resultDay = getDayData(configuration);
                return resultDay;
            }

            // Try and get Tasks
            IDataProividerResultTasksBase resultTask = getFileData(configuration);

            return resultTask;
        }

        private IDataProividerResultTasksBase getFileData(IDataSourceConfiguration configuration)
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

        public IDataProividerResultDayBase getDayData(IDataSourceConfiguration configuration)
        {

            IDataProividerResultDayBase result = new DataProviderResultDay();
            IsConfigurationValid(configuration);

            try
            {
                using (StreamReader r = new StreamReader(configuration.File.File))
                {
                    string json = r.ReadToEnd();
                    result.data = JsonConvert.DeserializeObject<DayFollowed>(json, new JsonSerializerSettings
                    {
                        DateFormatString = "yyyyMMddTHH:mm:ssZ"
                    });
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

        public IDataProviderResultBase SetData(IDataSourceConfiguration configuration, ITaskGroup tasks)
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
                    result = AddTaskToTasks(configuration.Task, tasks);
                }

                if (configuration.DeliteTask)
                {
                    result = RemoveTaskFromTasks(configuration.Task, tasks);
                }

                if (configuration.SetTask)
                {
                    result = SetTaskStatusInTasks(configuration.Task, tasks);
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

        public IDataProviderResultBase SetData(IDataSourceConfiguration configuration, IDayFollowed day)
        {
            IDataProividerResultDayBase result = WriteDayToFile(configuration, (DayFollowed)day);
            return result;
        }

        private IDataProividerResultTasksBase AddTaskToTasks(CLTask data, ITaskGroup tasks)
        {
            IDataProividerResultTasksBase result = new DataProviderResultTasks();
            ITaskGroup tasksCoppy = tasks.Clone();

            tasksCoppy.AddTask(data);
            result.data = tasksCoppy;
            result.sucess = true;

            return result;
        }

        private IDataProividerResultTasksBase RemoveTaskFromTasks(CLTask data, ITaskGroup tasks)
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

        private IDataProividerResultTasksBase SetTaskStatusInTasks(CLTask data, ITaskGroup tasks)
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

        private IDataProividerResultDayBase WriteDayToFile(IDataSourceConfiguration configuration, DayFollowed day)
        {
            IDataProividerResultDayBase result = new DataProviderResultDay();
            try
            {
                using (StreamWriter r = new StreamWriter(configuration.File.File))
                {
                    string data = JsonConvert.SerializeObject(day, new JsonSerializerSettings
                    {
                        DateFormatString = "yyyyMMddTHH:mm:ssZ"
                    });
                    r.Write(data);
                }
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
