using System;
using System.Data.Entity;

namespace GameTrader.Models
{
    public class FailedLoginAttempt
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string IPAddress { get; set; }
        public string Browser { get; set; }
        public DateTime TimeAttempted { get; set; }
    }

    public class FailedLoginContext : DbContext
    {
        public DbSet<FailedLoginAttempt> FailedLoginAttemptRecords { get; set; }
    }
}