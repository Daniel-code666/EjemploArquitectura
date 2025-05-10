namespace WebApiArch
{
    public class WebApiExceptions : Exception
    {
        public string _message = string.Empty;
        public int _status_code = 0;

        public WebApiExceptions(string message, int status_code)
        {
            _message = message;
            _status_code = status_code;
        }
    }
}
