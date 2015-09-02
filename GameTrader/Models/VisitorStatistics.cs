using System;
using System.Data.Entity;

namespace GameTrader.Models
{
    public class VisitorStatistic
    {
        public Guid ID { get; set; }
        public string UserName { get; set; }
        public string IPAddress { get; set; }
        public string AlternateIPAddress { get; set; }
        public string AreaAccessed { get; set; }
        public DateTime Timestamp { get; set; }
        public string Referer { get; set; }
        public string Browser { get; set; }
        public int ScreenResolutionHeight { get; set; } = 0;
        public int ScreenResolutionWidth { get; set; } = 0;

        public VisitorStatistic()
        {
        }
    }

    public class VisitorStatisticsContext : DbContext
    {
        public DbSet<VisitorStatistic> VisitorStatisticRecords { get; set; }
    }
}

