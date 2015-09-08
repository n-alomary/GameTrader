using System.Data.Entity;

namespace GameTrader.Models
{
    public class BrowserResolution
    {
        public int ID { get; set; }
        public string IPAddress { get; set; }
        public string BrowserResolutionHeight { get; set; }
        public string BrowserResolutionWidth { get; set; }
        public string Browser { get; set; }
    }

    class BrowserResolutionContext : ApplicationDbContext
    {
        DbSet<BrowserResolution> BrowserResolutionRecord { get; set; }
    }
}