using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace Tiantianquan.Common.WebApi.Filters
{
    public class ApiResultFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            var attrs1 = actionExecutedContext.ActionContext.ActionDescriptor.GetCustomAttributes<DontWrapperAttribute>();
            var attrs2 = actionExecutedContext.ActionContext.ControllerContext.ControllerDescriptor.GetCustomAttributes<DontWrapperAttribute>();
            if (attrs1.Count > 0 || attrs2.Count > 0)
            {
                return;
            }
            if (actionExecutedContext.Response == null || !actionExecutedContext.Response.IsSuccessStatusCode)
            {
                return;
            }
            AjaxResult result = new AjaxResult((int)HttpStatusCode.OK);

            if (actionExecutedContext.ActionContext.ActionDescriptor.ReturnType != typeof(void)
                && actionExecutedContext.Response.StatusCode == HttpStatusCode.OK)
            {
                result.Data = actionExecutedContext.Response.Content.ReadAsAsync<dynamic>().Result;
            }
            actionExecutedContext.Response = actionExecutedContext.Request.CreateResponse(HttpStatusCode.OK, result);
        }
    }
}