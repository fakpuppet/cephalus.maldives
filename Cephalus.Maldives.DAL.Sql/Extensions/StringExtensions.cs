namespace Cephalus.Maldives.DAL.Sql
{
    public static class StringExtensions
    {
        public static bool Like(this string target, string input)
        {
            if (target == null || input == null)
            {
                return true;
            }

            return target.ToLowerInvariant().Contains(input.ToLowerInvariant());
        }

        public static bool LeftLike(this string target, string input)
        {
            if (target == null)
            {
                return true;
            }

            return target.StartsWith(input, System.StringComparison.OrdinalIgnoreCase);
        }

        public static bool RightLike(this string target, string input)
        {
            if (target == null)
            {
                return true;
            }

            return target.EndsWith(input, System.StringComparison.OrdinalIgnoreCase);
        }
    }
}
