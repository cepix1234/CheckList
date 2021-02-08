using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CheckList.DataProviders.Interfaces;
using System.Configuration;
using System.Collections.Specialized;
using CheckList.DataProviders.Services;
using CheckList.Notification.Interfaces;
using CheckList.Notification.Constants;
using CheckList.TaskSpecifics.Interface;
using CheckList.TaskSpecifics.Class;

namespace CheckList
{
    public partial class MainMenu: Form
    {
        private readonly IDataProviderBase dataProvider;
        private readonly INotificationType notificationService;
        private readonly NotificationConstants notificationConstants;
        private readonly ITaskGroup tasks;

        private readonly DataSourceFileConfiguration fileConfiguration = new DataSourceFileConfiguration("SavedFiles\\Tasks.json");
        public MainMenu(IDataProviderBase dataProvider, INotificationType messageService, NotificationConstants notificationConstants, ITaskGroup tasks)
        {
            InitializeComponent();
            this.dataProvider = dataProvider;
            notificationService = messageService;
            this.notificationConstants = notificationConstants;
            this.tasks = tasks;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IDataSourceConfiguration dataSourceConfiguration = new DataSourceConfiguration(fileConfiguration);
            dataSourceConfiguration.GetAllTasks = true;
            IDataProividerResultTasksBase result = dataProvider.GetData(dataSourceConfiguration);
            if(!result.sucess)
            {
                notificationService.Error(notificationConstants.FileReadError("Tasks.json", result.error));
            }
            tasks.SetData(result.data);
        }

        private void button2_Click(object sender, EventArgs e)
        {

            string taskName = "TestTask";
            bool taskComplete = false;

            IDataSourceConfiguration dataSourceConfiguration = new DataSourceConfiguration(fileConfiguration, new TaskSpecifics.Class.Task(taskName, taskComplete));
            dataSourceConfiguration.AddTask = true;

            IDataProividerResultTasksBase result = dataProvider.SetData(dataSourceConfiguration, new TaskSpecifics.Class.Task(taskName, taskComplete), tasks);
            if (!result.sucess)
            {
                notificationService.Error(notificationConstants.FileWritingTaks("Tasks.json", result.error));
            }
            tasks.SetData(result.data);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string taskName = "TestTask";
            bool taskComplete = true;

            IDataSourceConfiguration dataSourceConfiguration = new DataSourceConfiguration(fileConfiguration, new TaskSpecifics.Class.Task(taskName, taskComplete));
            dataSourceConfiguration.SetTask = true;

            IDataProividerResultTasksBase result = dataProvider.SetData(dataSourceConfiguration, new TaskSpecifics.Class.Task(taskName, taskComplete), tasks);
            if (!result.sucess)
            {
                notificationService.Error(notificationConstants.FileWritingTaks("Tasks.json", result.error));
            }
            tasks.SetData(result.data);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string taskName = "TestTask";
            bool taskComplete = true;

            IDataSourceConfiguration dataSourceConfiguration = new DataSourceConfiguration(fileConfiguration, new TaskSpecifics.Class.Task(taskName, taskComplete));
            dataSourceConfiguration.DeliteTask = true;

            IDataProividerResultTasksBase result = dataProvider.SetData(dataSourceConfiguration, new TaskSpecifics.Class.Task(taskName, taskComplete), tasks);
            if (!result.sucess)
            {
                notificationService.Error(notificationConstants.FileWritingTaks("Tasks.json", result.error));
            }
            tasks.SetData(result.data);
        }
    }
}
