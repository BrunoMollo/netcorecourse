namespace NetCoreCourse.FirstExample.WebApp.Statics
{
    public static class StringExtensionMethods
    {
        public static string ToCUILFormat(this string cuit)
        {
            int l = cuit.Length;
            if (l < 4) return string.Empty; //or null maybe.

            cuit = cuit.Insert(l - 1, "/");
            cuit = cuit.Insert(2, "-");

            return cuit;
        }

        public static string UppercaseFirstLetter(this string text)
        {
            var first= text[0].ToString();
            var rest = text.Substring(1);
            return first.ToUpper() + rest.ToLower();
        }

        public static string forEachWord(this string text, Func<string, string> func)
        {
            var result = "";
            foreach (var word in text.Split(" ")) {
                result += func(word) + " ";
            }
            return result.Trim();
        }
    }
}
