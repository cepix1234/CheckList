using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckList.Notification.Interfaces
{
    public interface INotificationType
    {
        void Error(INotification message);

        void Warning(INotification message);

        void Message(INotification message);
    }
}
