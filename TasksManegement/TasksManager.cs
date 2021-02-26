using CheckList.DataProviders.Interfaces;
using CheckList.Notification.Constants;
using CheckList.Notification.Interfaces;
using CheckList.TaskSpecifics.Interface;
using CLTask = CheckList.TaskSpecifics.Class.Task;

namespace CheckList.TasksManegement
{
    public class TasksManager
    {

        public IDataSourceConfiguration dataSourceConfiguration;

        private readonly IDataProviderBase dataProvider;
        private readonly INotificationType notificationService;
        private readonly NotificationConstants notificationConstants;

        public TasksManager (IDataSourceConfiguration dataSourceConfiguration, IDataProviderBase dataProvider, INotificationType messageService, NotificationConstants notificationConstants)
        {
            this.dataSourceConfiguration = dataSourceConfiguration;
            this.dataProvider = dataProvider;
            this.notificationService = messageService;
            this.notificationConstants = notificationConstants;
        }

        public ITaskGroup GetAllTasks()
        {
            dataSourceConfiguration.Clear();
            this.dataSourceConfiguration.GetAllTasks = true;

            return GetData(dataSourceConfiguration);
        }

        public ITaskGroup AddTask(CLTask task, ITaskGroup tasks)
        {
            dataSourceConfiguration.Clear();
            dataSourceConfiguration.Task = task;
            dataSourceConfiguration.AddTask = true;

            return SetData(dataSourceConfiguration, tasks);
        }

        public ITaskGroup SetTask(CLTask task, ITaskGroup tasks)
        {
            dataSourceConfiguration.Clear();
            dataSourceConfiguration.Task = task;
            dataSourceConfiguration.SetTask = true;

            return SetData(dataSourceConfiguration, tasks);
        }

        public ITaskGroup RemoveTask(CLTask task, ITaskGroup tasks)
        {
            dataSourceConfiguration.Clear();
            dataSourceConfiguration.Task = task;
            dataSourceConfiguration.DeliteTask= true;

            return SetData(dataSourceConfiguration, tasks);
        }

        private ITaskGroup SetData(IDataSourceConfiguration configuration, ITaskGroup tasks)
        {
            IDataProividerResultTasksBase result = dataProvider.SetData(configuration, tasks);
            if (!result.sucess)
            {
                notificationService.Error(notificationConstants.FileWritingTaks("Tasks.json", result.error));
            }
            return result.data;
        }

        private ITaskGroup GetData(IDataSourceConfiguration configuration)
        {
            IDataProividerResultTasksBase result = dataProvider.GetData(configuration);
            if (!result.sucess)
            {
                notificationService.Error(notificationConstants.FileReadError("Tasks.json", result.error));
            }
            return result.data;
        }
    }
}
