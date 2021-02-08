using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckList.Notification.Interfaces;
using CheckList.Notification.Services;

namespace CheckList.Notification.Constants
{
    public class NotificationConstants
    {
        public INotification FileReadError(String file, String error)
        {
            return new NotificationContent("Error during file read!", $"Reading from file {file} failed with error: {error}.");
        }

        public INotification FileWritingTaks(String file, String error)
        {
            return new NotificationContent("Error during file writing!", $"Writing to file {file} failed with error: {error}.");
        }
    }
}
