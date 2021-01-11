using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckList.TaskSpecifics.Interface
{
    interface ITaskBase
    {
        String title
        {
            get;
            set;
        }

        Boolean finished
        {
            get;
            set;
        }
    }
}
