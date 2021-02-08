using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CheckList.Notification.Interfaces;

namespace CheckList.Notification.Services
{
    class MessageBoxNotification : INotificationType
    {
        readonly MessageBoxButtons okButton = MessageBoxButtons.OK;
        readonly MessageBoxButtons yesNoButton = MessageBoxButtons.YesNo;
        readonly MessageBoxButtons yesNoCancleButton = MessageBoxButtons.YesNoCancel;
        readonly MessageBoxButtons okCancleButton = MessageBoxButtons.OKCancel;

        readonly MessageBoxIcon errorIcon = MessageBoxIcon.Error;
        readonly MessageBoxIcon warnIcon = MessageBoxIcon.Warning;
        readonly MessageBoxIcon infoIcon = MessageBoxIcon.Information;


        DialogResult dialogResult;
        public void Error(INotification NotificationContent)
        {
            dialogResult = MessageBox.Show(NotificationContent.text, NotificationContent.title, okButton, errorIcon);
            if (dialogResult == System.Windows.Forms.DialogResult.OK)
            {
            }
        }

        public void Message(INotification message)
        {
            throw new NotImplementedException();
        }

        public void Warning(INotification message)
        {
            throw new NotImplementedException();
        }
    }
}
