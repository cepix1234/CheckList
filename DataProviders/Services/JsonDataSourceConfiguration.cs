using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckList.DataProviders.Interfaces;

namespace CheckList.DataProviders.Services
{
    class JsonDataSourceConfiguration : IDataSourceFileConfiguration
    {
        public JsonDataSourceConfiguration (String file)
        {
            this.File = file;
        }

        public string File { 
            get; 
            set;
        }
    }
}
