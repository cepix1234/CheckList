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

namespace CheckList
{
    public partial class MainMenu: Form
    {
        IDataProviderBase dataProvider;
        public MainMenu()
        {
            InitializeComponent();
            string dataProviderType = ConfigurationManager.AppSettings.Get("dataProvider");
            switch (dataProviderType) {
                case "Json":
                    dataProvider = new JsonProvider();
                    break;
                default:
                    throw new Exception("Not supported data provider type!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IDataSourceFileConfiguration taskFileConfiguration = new JsonDataSourceConfiguration("SavedFiles\\Tasks.json");
            IDataProividerResultTasksBase result = dataProvider.GetData(taskFileConfiguration);
            //TODO Replace with errorMessage class.
            if(!result.sucess)
            {
                string message = "You did not enter a server name. Cancel this operation?";
                string caption = "Error Detected in Input";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult dialogResult;

                // Displays the MessageBox.
                dialogResult = MessageBox.Show(message, caption, buttons);
                if (dialogResult == System.Windows.Forms.DialogResult.Yes)
                {
                    // Closes the parent form.
                    this.Close();
                }
            }
        }
    }
}
