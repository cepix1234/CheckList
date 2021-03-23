using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckList.FollowingDays.Interfaces
{
    public interface IDayFollowed
    {
        DateTime Date
        {
            get;
            set;
        }

        DateTime datetime
        {
            get;
            set;
        }
    }
}
