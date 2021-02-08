using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckList.Notification.Interfaces
{
    public interface INotification
    {
        String title
        {
            get;
            set;
        }
        String text
        {
            get;
            set;
        }

    }
}
