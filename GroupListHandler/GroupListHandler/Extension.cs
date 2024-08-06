namespace GroupListHandler
{
    public static class Extension
    {
        public static string removeAll(this string data, string remove)
        {
            while (data.Contains(remove))
            {
                data = data.Replace(remove, string.Empty);
            }
            return data;
        }
    }
}