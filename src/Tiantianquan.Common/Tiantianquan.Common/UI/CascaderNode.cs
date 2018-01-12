using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tiantianquan.Common.UI
{
    /// <summary>
    /// ant 级联选择数据
    /// </summary>
   public class CascaderNode
    {
        [JsonProperty("label")]
        public string Label { get; set; }
        [JsonProperty("value")]
        public string Value { get; set; }
        [JsonProperty("isLeaf")]
        public bool IsLeaf { get; set; }
        [JsonProperty("children")]
        public List<CascaderNode> Children { get; set; }

        public CascaderNode()
        {
            this.Children = new List<CascaderNode>();
        }
    }
}
