namespace WebApi.Common
{ 
    public static class Utils
    {
        public static String GetSafeString(String? value)
            => !String.IsNullOrEmpty(value) ? value : String.Empty;
    }
}
