using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace Tiantianquan.Common
{
    /// <summary>
    /// 时间序列化成时间戳
    /// </summary>
    public class AppDateTimeConverter : DateTimeConverterBase
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            long ticks = 0;
            if (value is DateTime)
            {
                var epoc = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
                var date = TimeZone.CurrentTimeZone.ToLocalTime((DateTime)value);
                var delta = date.Ticks - epoc.Ticks;
                if (delta < 0)
                {
                    delta = 0;
                }
                ticks = delta / 10000;
            }

            writer.WriteValue(ticks);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Integer)
            {
                var ticks = (long)reader.Value;
                var date = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
                date = date.AddTicks(ticks);
                return date;
            }
            return DateTime.MinValue;
        }
    }
}