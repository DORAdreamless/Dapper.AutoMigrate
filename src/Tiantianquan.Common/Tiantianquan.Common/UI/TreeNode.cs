using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tiantianquan.Common.UI
{
    /// <summary>
    /// 树节点
    /// </summary>
    public class TreeNode
    {
        /// <summary>
        /// 无子节点
        /// </summary>
        public const string Open = "open";

        /// <summary>
        /// 有
        /// </summary>
        public const string Closed = "closed";
        /// <summary>
        /// Id
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }
        /// <summary>
        /// 文字
        /// </summary>
        [JsonProperty("text")]
        public string Text { get; set; }
        /// <summary>
        /// 状态，值为：open,closed
        /// </summary>
        [JsonProperty("state")]
        public string State { get; set; }
        /// <summary>
        /// 是否选择
        /// </summary>
        [JsonProperty("checked")]
        public bool Checked { get; set; }
        /// <summary>
        /// 其他属性
        /// </summary>
        [JsonProperty("attributes")]
        public object Attributes { get; set; }
        /// <summary>
        /// 子节点
        /// </summary>
        [JsonProperty("children")]
        public List<TreeNode> Children { get; set; }
    }
}
