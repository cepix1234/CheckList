using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CheckList.FollowingDays.Class;
using CheckList.FollowingDays.Interfaces;
using Newtonsoft.Json;
using CheckList.DataProviders.Interfaces;

namespace CheckList.FollowingDays.Services
{
    class DayFollower : IDayFollower
    {
        private IDayFollowed _DayFollowed;
        private IDayFollowed _CurrentDay;
        private HttpClient Client;
        private IDataProviderBase dataProvider;
        private IDataSourceConfiguration dataSourceConfiguration;
        public IDayFollowed DayFollowed
        {
            get => _DayFollowed;
        }

        public DayFollower(IDayFollowed dayFollowed, IDataProviderBase dataProvider, IDataSourceConfiguration dataSourceConfiguration)
        {
            this._DayFollowed = dayFollowed;
            this.Client = new HttpClient();
            this.dataProvider = dataProvider;
            this.dataSourceConfiguration = dataSourceConfiguration;
        }

        public async Task<bool> IsNewDay()
        {
            await this.GetNewDay();
            return CheckDates();
        }

        public async Task<string> GetNewDay()
        {
            HttpResponseMessage response = await this.Client.GetAsync("http://worldtimeapi.org/api/ip");
            if (response.IsSuccessStatusCode)
            {
                string responseString = await response.Content.ReadAsStringAsync();
                this._CurrentDay = JsonConvert.DeserializeObject<DayFollowed>(responseString, new JsonSerializerSettings
                {
                    DateFormatString = "yyyyMMddTHH:mm:ssZ"
                });
            }
            return this._CurrentDay.datetime.ToString();
        }

        public async Task<bool> SetNewDay()
        {
            await this.GetNewDay();
            if(CheckDates())
            {
                this._DayFollowed.Date = this._CurrentDay.datetime;
            }

            dataProvider.SetData(dataSourceConfiguration, this._DayFollowed);
            return true;
        }

        private bool CheckDates()
        {
            int diff = this._DayFollowed.Date.CompareTo(this._CurrentDay.datetime);
            if(diff < 0)
            {
                return true;
            }
            return false;
        }

    }
}
