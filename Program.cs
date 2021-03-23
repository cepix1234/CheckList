using System;
using System.Configuration;
using System.Windows.Forms;
using CheckList.DataProviders.Interfaces;
using CheckList.DataProviders.Services;
using CheckList.Notification.Interfaces;
using CheckList.Notification.Services;
using CheckList.Notification.Constants;
using CheckList.TaskSpecifics.Interface;
using CheckList.TasksManegement;
using CheckList.FollowingDays.Class;
using CheckList.FollowingDays.Services;
using CheckList.FollowingDays.Interfaces;
using System.Threading.Tasks;

namespace CheckList
{
    static class Program
    {
        static IDataProviderBase dataProvider;
        static INotificationType notificationService;
        static NotificationConstants notificationConstants;
        static TasksManager tasksManager;
        static DayFollower dayFollower;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static async Task Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Initialize needed classes.
            dataProvider = InitializeDataprovider();
            notificationService = InitializeNotification();
            notificationConstants = new NotificationConstants();
            tasksManager = InitializeTasksManager(dataProvider, notificationService, notificationConstants);

            // get all tasks.
            ITaskGroup tasks = tasksManager.GetAllTasks();

            //Get current date and save if its new day.
            dayFollower = InitializeDayFollower(dataProvider);
            await dayFollower.SetNewDay();

            //! Change
            var timer = new System.Threading.Timer(
                async e => await dayFollower.SetNewDay(),
                null,
                TimeSpan.Zero,
                TimeSpan.FromMinutes(30));


            // start the check list view.
            Application.Run(new CheckListApp(tasksManager, tasks));
        }

        static IDataProviderBase InitializeDataprovider()
        {
            string dataProviderType = ConfigurationManager.AppSettings.Get("dataProvider");
            IDataProviderBase dataProvider;
            switch (dataProviderType)
            {
                case "Json":
                    dataProvider = new JsonProvider();
                    break;
                default:
                    throw new Exception("Not supported data provider type!");
            }
            return dataProvider;
        }

        static TasksManager InitializeTasksManager (IDataProviderBase dataProvider, INotificationType messageService, NotificationConstants notificationConstants)
        {
            string folderName = ConfigurationManager.AppSettings.Get("FileFolder");
            string fileName = ConfigurationManager.AppSettings.Get("TasksFileName");
            //string fileName = ConfigurationManager.AppSettings.Get("DayCoveredFileName");

            return new TasksManager(
                new DataSourceConfiguration(new DataSourceFileConfiguration($"{folderName}\\{fileName}")),
                dataProvider,
                messageService,
                notificationConstants
                );
        }

        static INotificationType InitializeNotification()
        {
            string notificationType = ConfigurationManager.AppSettings.Get("notificationType");
            INotificationType messageService;
            switch (notificationType)
            {
                case "MessageBox":
                    messageService = new MessageBoxNotification();
                    break;
                default:
                    throw new Exception("Not supported notification type!");
            }
            return messageService;
        }

        static DayFollower InitializeDayFollower(IDataProviderBase dataProvider)
        {
            string folderName = ConfigurationManager.AppSettings.Get("FileFolder");
            string dayFollowingFile = ConfigurationManager.AppSettings.Get("DayCoveredFileName");

            IDataSourceConfiguration dataSourceConfiguration = new DataSourceConfiguration(new DataSourceFileConfiguration($"{folderName}\\{dayFollowingFile}"));
            dataSourceConfiguration.getDayFollowd = true;

            IDataProividerResultDayBase dayFollowed = (IDataProividerResultDayBase)dataProvider.GetData(dataSourceConfiguration);

            return new DayFollower(dayFollowed.data, dataProvider, dataSourceConfiguration);
        }
    }
}
