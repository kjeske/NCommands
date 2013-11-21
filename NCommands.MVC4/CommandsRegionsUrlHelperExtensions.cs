using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;

namespace NCommands.MVC
{
    public static class CommandsRegionsUrlHelperExtensions
    {
         public static IEnumerable<CommandsRegionResult> Commands(this UrlHelper urlHelper, string regionName, object routeData = null)
         {
             var routeDictionary = new RouteValueDictionary(urlHelper.RequestContext.RouteData.Values);

             if (routeData != null)
             {
                 var passedRouteDictionary = new RouteValueDictionary(routeData);

                 foreach (var item in passedRouteDictionary)
                 {
                     if (!routeDictionary.ContainsKey(item.Key))
                     {
                         routeDictionary.Add(item.Key, item.Value);
                     }
                 }
             }

             return CommandsRegionsManager.Default.Resolve(urlHelper, regionName, routeDictionary);
         }
    }
}