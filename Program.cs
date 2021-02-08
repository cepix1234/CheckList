using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CheckList.DataProviders.Interfaces;
using CheckList.DataProviders.Services;
using CheckList.Notification.Interfaces;
using CheckList.Notification.Services;
using CheckList.Notification.Constants;
using CheckList.TaskSpecifics.Interface;
using CheckList.TaskSpecifics.Class;

namespace CheckList
{
    static class Program
    {
        static IDataProviderBase dataProvider;
        static INotificationType notificationService;
        static NotificationConstants notificationConstants;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            dataProvider = InitializeDataprovider();
            notificationService = InitializeNotification();
            notificationConstants = new NotificationConstants();
            ITaskGroup tasks = InitializeTaskgroup();

            Application.Run(new MainMenu(dataProvider, notificationService, notificationConstants, tasks));
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

        static ITaskGroup InitializeTaskgroup()
        {
            DataSourceFileConfiguration fileConfiguration = new DataSourceFileConfiguration("SavedFiles\\Tasks.json");
            IDataSourceConfiguration dataSourceConfiguration = new DataSourceConfiguration(fileConfiguration);
            dataSourceConfiguration.GetAllTasks = true;
            IDataProividerResultTasksBase result = dataProvider.GetData(dataSourceConfiguration);
            if (!result.sucess)
            {
                notificationService.Error(notificationConstants.FileReadError("Tasks.json", result.error));
            }
            return result.data;
        }
    }
}
