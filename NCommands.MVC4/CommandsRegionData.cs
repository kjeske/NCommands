using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace NCommands.MVC
{
    public class CommandsRegionData
    {
        public string DisplayName { get; set; }

        public Func<UrlHelper, IDictionary<string, dynamic>, string> Action { get; set; }

        internal string CommandName { get; set; }
    }
}