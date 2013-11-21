using System.Web.Mvc;

namespace NCommands.MVC4
{
    public abstract class WebCommand : Command
    {
        public abstract string ExecuteUrl(UrlHelper urlHelper);

        public override void Execute()
        {
            // Empty implementation

            // Execution is done by the action method in controller
        }

        protected UrlHelper GetUrlHelper()
        {
            return new UrlHelper(System.Web.HttpContext.Current.Request.RequestContext);
        }
    }
}