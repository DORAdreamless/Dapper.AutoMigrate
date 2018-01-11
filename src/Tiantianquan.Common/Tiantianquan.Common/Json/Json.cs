using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;

namespace Tiantianquan.Common
{
    public sealed class Json
    {
        /// <summary>
        ///     序列化
        /// </summary>
        /// <param name="value">对象</param>
        /// <param name="cameCase">是否转为小写开头</param>
        /// <param name="indented">是否格式化</param>
        /// <returns></returns>
        public static string SerializeObject(object value, bool cameCase = true, bool indented = true)
        {
            var options = GetJsonSerializerSettings(cameCase, indented);
            return JsonConvert.SerializeObject(value, options);
        }

        /// <summary>
        ///     反序列化
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="json">json字符串</param>
        /// <returns></returns>
        public static T DeserializeObject<T>(string json)
        {
            var options = new JsonSerializerSettings();
            options.Converters.Insert(0, new AppDateTimeConverter());
            return JsonConvert.DeserializeObject<T>(json, options);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="json"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object DeserializeObject(string json, Type type)
        {
            var options = new JsonSerializerSettings();
            options.Converters.Insert(0, new AppDateTimeConverter());
            return JsonConvert.DeserializeObject(json, type, options);
        }

        public static JsonSerializerSettings GetJsonSerializerSettings(bool cameCase = true,
            bool indented = true)
        {
            var options = new JsonSerializerSettings();
            if (cameCase)
            {
                options.ContractResolver = new CamelCasePropertyNamesContractResolver();
            }
            if (indented)
            {
                options.Formatting = Formatting.Indented;
            }
            options.Converters.Insert(0, new AppDateTimeConverter());
            return options;
        }
    }
}