using GameTrader.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameTrader.DAL
{
    public class TrackVisitorAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            // store the request in an accessible object 
            var request = filterContext.HttpContext.Request;
            //generate a visitor statistic record. 
            VisitorStatistic visitor = new VisitorStatistic()
            {
                UserName = (request.IsAuthenticated) ? filterContext.HttpContext.User.Identity.Name : "Annonymous",
                IPAddress = request.UserHostAddress ?? request.ServerVariables["HTTP_X_FORWARDED_FOR"],
                AlternateIPAddress = request.ServerVariables["REMOTE_ADDR"] ?? "Not Available",
                AreaAccessed = request.RawUrl,
                Timestamp = DateTime.UtcNow,
                Referer = request.ServerVariables["HTTP_REFERER"] ?? "internet",
                Browser = request.Browser.Browser
            }; 
            // stores the tracked info in the database 
            VisitorStatisticsContext context = new VisitorStatisticsContext();
            context.VisitorStatisticRecords.Add(visitor);
            context.SaveChanges();

            //finished executing the action as normal 
            base.OnActionExecuting(filterContext);
        }
    }
}