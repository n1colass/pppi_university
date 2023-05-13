using System.Net;

namespace RestAPI.Models.DTO
{
    public class NewException : Exception
    {
        public NewException(string message) : base(message)
        {
        }
    }
}
