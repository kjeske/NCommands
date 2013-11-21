using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace NCommands.MVC
{
    public class CommandsRegionData
    {
        public string DisplayName { get; set; }

        public Func<UrlHelper, RouteValueDictionary, string> Action { get; set; }

        internal string CommandName { get; set; }
    }
}