using System.Net;

namespace Lab_5.API
{
    public class HandleDTO
    {
        public string errorMessage { get; set; }
        public HttpStatusCode httpStatusCode { get; set; }
        public List<ProductDTO> products { get; set; }
    }

    public class ProductDTO
    {
        public string _id { get; set; }
        public string title { get; set; }
        public string category { get; set; }
        public double price { get; set; }
        public int __v { get; set; }
    }
}
