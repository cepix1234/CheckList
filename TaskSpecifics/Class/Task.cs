using CheckList.TaskSpecifics.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckList.TaskSpecifics.Class
{
    class Task : ITaskBase
    {
        public string title { 
            get; 
            set;
        }

        public bool finished { 
            get; 
            set; 
        }
    }
}
