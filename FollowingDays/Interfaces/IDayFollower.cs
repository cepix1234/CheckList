using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckList.FollowingDays.Interfaces
{
    public interface IDayFollower
    {
        IDayFollowed DayFollowed 
        { 
            get; 
        }

        Task<string> GetNewDay();

        Task<bool> IsNewDay();

        Task<bool> SetNewDay();
    }
}
