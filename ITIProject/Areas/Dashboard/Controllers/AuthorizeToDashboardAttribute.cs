using Microsoft.AspNet.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;

namespace ITIProject.Areas.Dashboard.Controllers
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    internal class AuthorizeToDashboardAttribute : AuthorizeAttribute
    {

        //protected override bool AuthorizeCore(HttpContextBase httpContext)
        //{
        //    bool disableAuthentication = false;

        //   #if DEBUG
        //    disableAuthentication = true;
        //   #endif

        //    if (disableAuthentication)
        //        return true;

        //    return base.AuthorizeCore(httpContext);
        //}

        //protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        //{
        //    if (User.Identity.IsAuthenticated)
        //    {
        //        return RedirectToAction("Index", "Manage",new { area=""});
        //    }
        //}
    }
}