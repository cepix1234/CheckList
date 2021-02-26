using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckList.DayFollower.Interfaces;

namespace CheckList.DayFollower.Class
{
    public class DayFollowed : IDayFollowed
    {
        public DateTime Date {
            get;
            set;
        }
    }
}
