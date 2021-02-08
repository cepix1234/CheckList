using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckList.Notification.Interfaces;

namespace CheckList.Notification.Services
{
    class NotificationContent : INotification
    {

        public NotificationContent(String title, String text)
        {
            this.title = title;
            this.text = text;
        }
        public string title
        {
            get;
            set;
        }
        public string text
        {
            get;
            set;
        }
    }
}
