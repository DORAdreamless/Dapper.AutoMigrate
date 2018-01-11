
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Tiantianquan.Common.WebApi.Attributes;

namespace Tiantianquan.Common.WebApi.Filters
{
    public class ApiValidateModelFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (actionContext.ActionDescriptor.GetCustomAttributes<ValidatorAttribute>() == null)
            {
                return;
            }
            if (!actionContext.ModelState.IsValid)
            {
                var errs = actionContext.ModelState.Select(item => new
                {
                    Field = item.Key.Substring(item.Key.LastIndexOf(".") + 1),
                    Value = item.Key.Substring(item.Key.LastIndexOf(".") + 1),
                    Valid = false,
                    Message = item.Value.Errors.FirstOrDefault(err => !string.IsNullOrWhiteSpace(err.ErrorMessage))?.ErrorMessage
                });
                if (!errs.Any(err => !string.IsNullOrWhiteSpace(err.Message)))
                {
                    return;
                }
                errs = errs.Where(item => !string.IsNullOrWhiteSpace(item.Message));
                AjaxResult result = new AjaxResult((int)HttpStatusCode.BadRequest);
                result.Data = errs;
                result.Message = errs.FirstOrDefault().Message;
                result.Success = false;
            
                //  actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.OK, errs);
            }
        }
    }
}