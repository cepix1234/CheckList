using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckList.DataProviders.Interfaces;

namespace CheckList.DataProviders.Services
{
    public class DataSourceFileConfiguration : IDataSourceFileConfiguration
    {
        public DataSourceFileConfiguration(string File)
        {
            this.File = File;
        }

        public string File 
        { 
            get; 
            set; 
        }
    }
}
