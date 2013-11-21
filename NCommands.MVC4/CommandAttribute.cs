using System.Net;
using System.Web.Mvc;

namespace NCommands.MVC4
{
    public class CommandAttribute : AuthorizeAttribute
    {
        public string Name { get; set; }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);

            if (!AuthorizeCore(filterContext.HttpContext))
            {
                return;
            }

            if (!CheckCommand(filterContext))
            {
                HandleForbiddenRequest(filterContext);
            }
        }

        private void HandleForbiddenRequest(AuthorizationContext filterContext)
        {
            if (!filterContext.HttpContext.Request.IsAjaxRequest())
            {
                filterContext.Result = new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }
            else
            {
                filterContext.Result = new JsonResult { Data = new { success = false, status = HttpStatusCode.Forbidden } };
            }
        }

        private bool CheckCommand(AuthorizationContext filterContext)
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                return true;
            }

            var command = CommandsManager.Default.GetCommand(Name);

            if (command == null)
            {
                return false;
            }

            command.Parameters = filterContext.RouteData.Values;

            return command.CanExecute();
        }
    }
}