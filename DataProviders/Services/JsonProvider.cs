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
        public IDataProividerResultTasksBase GetData(IDataSourceFileConfiguration configuration)
        {
            // Validations
            if (configuration.File == "undefined" || configuration.File == null)
            {
                throw new Exception("Configuration file is not defined");
            }


            IDataProividerResultTasksBase result = new DataProviderResultTasks();

            try
            {
                using (StreamReader r = new StreamReader(configuration.File))
                {
                    string json = r.ReadToEnd();
                    result.data = JsonConvert.DeserializeObject<TaskGroup>(json);
                }
            } catch(Exception error)
            {
                result.sucess = false;
                result.error = error.Message; 
            }

            result.sucess = true;

            return result;
        }

        public IDataProviderResultBase SetData(IDataSourceFileConfiguration configuration, ITaskBase data)
        {
            throw new NotImplementedException();
        }
    }
}
