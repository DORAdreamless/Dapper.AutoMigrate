using Newtonsoft.Json;
using System.Net;

namespace Tiantianquan.Common.WebApi
{
    public class AjaxResult
    {
        public const string SUCCESS_MESSAGE = "操作成功。";

        public const string FAILURE_MESSAGE = "操作出现错误，请重试或与管理员联系。";

        public const string VALIDATION_MESSAGE = "数据校验错误。";

        /// <summary>
        /// 代码
        /// </summary>
        [JsonProperty("code")]
        public int Code { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonProperty("success")]
        public bool Success { get; set; }

        /// <summary>
        /// 消息
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }

        /// <summary>
        /// 数据
        /// </summary>
        [JsonProperty("data")]
        public dynamic Data { get; set; }

        public AjaxResult()
        {
            Message = SUCCESS_MESSAGE;
        }

        public AjaxResult(int code)
        {
            this.Code = code;
            if (code == (int)HttpStatusCode.OK)
            {
                this.Success = true;
                this.Message = SUCCESS_MESSAGE;
            }
            else
            {
                this.Success = false;
                this.Message = FAILURE_MESSAGE;
            }
        }

        public AjaxResult(int code, bool success, string message, dynamic data)
        {
            Code = code;
            Success = success;
            Message = message;
            Data = data;
        }
    }
}