using System.Text;

namespace Dapper.AutoMigrate.Utility
{
    public class StringUtils
    {
        public static  string GetSnackName(string text)
        {
            StringBuilder builder = new StringBuilder();
            foreach (char c in text)
            {
                if (char.IsWhiteSpace(c))
                {
                    continue;
                }
                if (char.IsUpper(c))
                {
                    builder.Append("_");
                }
                else
                {
                    builder.Append(c);
                }
            }
            return builder.ToString();
        }
    }

   

}
