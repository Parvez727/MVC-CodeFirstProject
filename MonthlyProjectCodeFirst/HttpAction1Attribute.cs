using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace MonthlyProjectCodeFirst
{
    public class HttpAction1Attribute : ActionNameSelectorAttribute
    {
        public override bool IsValidName(ControllerContext controllerContext, string actionName, MethodInfo methodInfo)
        {
            if (actionName.Equals(methodInfo.Name,
            StringComparison.InvariantCultureIgnoreCase))
                return true;
            var request = controllerContext.RequestContext.HttpContext.Request;
            return request[methodInfo.Name] != null;
        }
    }

}