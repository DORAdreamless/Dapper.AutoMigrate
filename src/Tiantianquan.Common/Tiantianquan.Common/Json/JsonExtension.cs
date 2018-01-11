namespace Tiantianquan.Common
{
    public static class JsonExtension
    {
        public static string ToJson(this object data, bool cameCase = true, bool indented = true)
        {
            return Json.SerializeObject(data, cameCase, indented);
        }
    }
}