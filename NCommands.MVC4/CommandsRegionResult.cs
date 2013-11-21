using System.Collections.Generic;
using System.Web.Mvc;

namespace NCommands.MVC
{
    public class CommandsRegionResult
    {
        public CommandsRegionResult()
        { }

        public CommandsRegionResult(CommandsRegionData item, UrlHelper urlHelper, IDictionary<string, dynamic> parameters)
        {
            DisplayName = item.DisplayName;
            Url = item.Action(urlHelper, parameters);
        }

        public string DisplayName { get; set; }

        public string Url { get; set; }
    }
}