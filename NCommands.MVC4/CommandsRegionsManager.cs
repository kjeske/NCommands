﻿using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;

namespace NCommands.MVC
{
    /// <summary>
    /// Instance per application
    /// </summary>
    public class CommandsRegionsManager
    {
        private readonly IDictionary<string, IList<CommandsRegionData>> _items;

        private static CommandsRegionsManager defaultInstance;

        public static CommandsRegionsManager Default
        {
            get { return defaultInstance ?? (defaultInstance = new CommandsRegionsManager()); }
        }

        public CommandsRegionsManager()
        {
            _items = new Dictionary<string, IList<CommandsRegionData>>();
        }

        public void Attach(string regionName, string commandName, string displayName, Func<UrlHelper, IDictionary<string, dynamic>, string> url)
        {
            if (!_items.ContainsKey(regionName))
            {
                _items.Add(regionName, new List<CommandsRegionData>());
            }

            var regionData = new CommandsRegionData
            {
                DisplayName = displayName,
                Action = url,
                CommandName = commandName
            };

            _items[regionName].Add(regionData);
        }

        public IEnumerable<CommandsRegionData> List(string regionName)
        {
            return _items.ContainsKey(regionName) ? _items[regionName] : new List<CommandsRegionData>();
        }

        public IEnumerable<CommandsRegionResult> Resolve(UrlHelper urlHelper, string regionName, RouteValueDictionary routeData = null)
        {
            var result = new List<CommandsRegionResult>();

            foreach (var commandData in List(regionName))
            {
                var command = CommandsManager.Default.GetCommand(commandData.CommandName);

                command.Parameters = routeData;

                if (!command.CanExecute())
                {
                    continue;
                }

                result.Add(new CommandsRegionResult(commandData, urlHelper, routeData));
            }

            return result;
        }
    }
}