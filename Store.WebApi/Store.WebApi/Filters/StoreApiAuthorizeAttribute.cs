using System;
using System.Linq;
using System.Web.Configuration;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace Store.WebApi
{
    public class StoreApiAuthorizeAttribute : AuthorizeAttribute
    {
        //private DatabaseContext db = new DatabaseContext();
        public override void OnAuthorization(HttpActionContext filterContext)
        {
            if (Authorize(filterContext))
            {
                return;
            }
            HandleUnauthorizedRequest(filterContext);
        }
        protected override void HandleUnauthorizedRequest(HttpActionContext filterContext)
        {
            base.HandleUnauthorizedRequest(filterContext);
        }

        private bool Authorize(HttpActionContext actionContext)
        {
            try
            {
                var encodedString = actionContext.Request.Headers.GetValues(WebConfigurationManager.AppSettings["TokenParameter"]).First();
                bool validFlag = true;

                if (!string.IsNullOrWhiteSpace(encodedString))
                {
                    //here we can validate the user by token
                    //TO DO
                }
                return validFlag;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}