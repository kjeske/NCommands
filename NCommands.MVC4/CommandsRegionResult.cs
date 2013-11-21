using System.Web.Mvc;
using System.Web.Routing;

namespace NCommands.MVC
{
    public class CommandsRegionResult
    {
        public CommandsRegionResult()
        { }

        public CommandsRegionResult(CommandsRegionData item, UrlHelper urlHelper, RouteValueDictionary routeData)
        {
            DisplayName = item.DisplayName;
            Url = item.Execute(urlHelper, routeData);
        }

        public string DisplayName { get; set; }

        public string Url { get; set; }
    }
}