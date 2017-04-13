namespace SyndicateMobApp.Helpers
{
    public static class Uti
    {
        public static string NumericNormalize(this string accentedStr)
        {
            string output = string.Empty;
            foreach (char c in accentedStr)
            {
                output = string.Concat(output, char.GetNumericValue(c).ToString());
            }
            return output;
        }
    }
}
