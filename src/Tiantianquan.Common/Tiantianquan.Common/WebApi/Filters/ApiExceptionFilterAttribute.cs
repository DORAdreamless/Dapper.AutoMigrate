
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http.Filters;
using Tiantianquan.Common.Dependency;
using Tiantianquan.Common.Logging;

namespace Tiantianquan.Common.WebApi.Filters
{
    public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            // 取得发生例外时的错误讯息
            var exception = GetInnerException(actionExecutedContext.Exception);

            var result = new AjaxResult((int)HttpStatusCode.InternalServerError);

            //手动引发的异常无需处理
            if (exception is FriendlyException)
            {
                var userFriendlyException = exception as FriendlyException;
                result.Message = userFriendlyException.Message;
            }
            else
            {
                result.Code = (int)HttpStatusCode.InternalServerError;
                result.Success = false;

                StringBuilder builder = new StringBuilder();
                builder.Append("请求地址：").Append(actionExecutedContext.Request.RequestUri.AbsoluteUri).AppendLine();
                builder.AppendLine("错误信息：" + exception.Message);
                builder.AppendLine("请求参数：");
                builder.AppendLine(ConvertArgumentsToJson(actionExecutedContext));
                builder.AppendLine("堆栈信息：" + exception.StackTrace);
                var logger=ObjectContainer.Current.Resolve<ILoggerFactory>().Create(typeof(ApiExceptionFilterAttribute));
                logger.Error(builder.ToString(),exception);
            }

            // 重新封装回传格式
            actionExecutedContext.Response = actionExecutedContext.Request.CreateResponse(HttpStatusCode.OK, result);
        }

        private static string ConvertArgumentsToJson(HttpActionExecutedContext actionExecutedContext)
        {
            var arguments = actionExecutedContext.ActionContext.ActionArguments;
            return arguments.ToJson();
        }

        private Exception GetInnerException(Exception exception)
        {
            if (exception.InnerException == null)
                return exception;
            return exception.InnerException;
        }
    }
}