using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VirtualWellnessProgram.Models;

namespace VirtualWellnessProgram.Audit
{
    public class AuditAttribute: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var request = filterContext.HttpContext.Request;
            Models.Audit audit = new Models.Audit()
                {
                    AuditId  = Guid.NewGuid(),
                    UserName = (request.IsAuthenticated) ? filterContext.HttpContext.User.Identity.Name : "Anonymous",
                    AreaAccessed = request.RawUrl,
                    Timestamp = DateTime.Now.ToString("MM/dd/yyyy")
                };

            AuditingContext context = new AuditingContext();
            context.AuditRecords.Add(audit);
            context.SaveChanges();

           base.OnActionExecuting(filterContext);
        }
    }
}