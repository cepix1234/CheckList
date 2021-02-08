using CheckList.TaskSpecifics.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckList.TaskSpecifics.Class
{
    public class Task : ITaskBase
    {

        public Task(String title, Boolean finished)
        {
            this.title = title;
            this.finished = finished;
        }

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
