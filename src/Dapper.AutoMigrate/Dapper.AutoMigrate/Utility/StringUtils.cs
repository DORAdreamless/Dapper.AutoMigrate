using System.Text;

namespace Dapper.AutoMigrate.Utility
{
    public class StringUtils
    {
        public static  string GetSnackName(string text)
        {
            StringBuilder builder = new StringBuilder();
            int counter = 0;
            foreach (char c in text)
            {
                if (char.IsWhiteSpace(c))
                {
                    continue;
                }
                if (counter > 0)
                {
                    if (char.IsUpper(c))
                    {
                        builder.Append("_");
                    }
                }
                builder.Append(c);
                counter++;
            }
            return builder.ToString().ToLower();
        }
    }

   

}
