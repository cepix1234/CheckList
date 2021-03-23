using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckList.FollowingDays.Interfaces;

namespace CheckList.FollowingDays.Class
{
    public class DayFollowed : IDayFollowed
    {
        public DateTime Date {
            get;
            set;
        }

        public DateTime datetime
        { 
            get;
            set;
        }
    }
}
