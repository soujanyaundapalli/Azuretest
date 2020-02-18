using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace proficiencytoday.Filters
{
    public class CustomAuth:AuthorizeAttribute
    {
        public string ViewName;
        public CustomAuth()
        {
            ViewName = "AuthorizationFailed";
        }
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
            IsAuthorized(filterContext);
        }

        private void IsAuthorized(AuthorizationContext filterContext)
        {
           if(filterContext.Result==null)
            {
                return;
            }
           if(filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                var vr = new ViewResult();
                vr.ViewName = ViewName;
                ViewDataDictionary vd = new ViewDataDictionary();
                vd.Add("Message", "You are not authorized to view this view");
                vr.ViewData = vd;
                var result = vr;
                filterContext.Result = result;
                
            }
        }
    }
}