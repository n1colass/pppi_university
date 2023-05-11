using Lab_5.API;

namespace Lab_5.Program
{
    internal class Program
    {
        public static async Task Main()
        {
            Api apiClient = new Api();

            Console.WriteLine("-----------------Get-----------------");
            var getData = await apiClient.GetAll();
            Console.WriteLine(getData.httpStatusCode);
            Console.WriteLine(getData.errorMessage);
            Console.WriteLine(getData.products);
            foreach (var product in getData.products)
            {
                Console.WriteLine($"Id: {product._id} Title: {product.title} Category: {product.category} Price: {product.price} V: {product.__v}");
            }

            Console.WriteLine("-----------------Post-----------------");
            List<string> categories = new List<string>();
            categories.Add("Fruits");
            categories.Add("Fast food");
            var getCategory = await apiClient.GetCategory(categories);
            Console.WriteLine(getCategory.httpStatusCode);
            Console.WriteLine(getCategory.errorMessage);
            Console.WriteLine(getCategory.products);
            foreach (var product in getCategory.products)
            {
                Console.WriteLine($"Id: {product._id} Title: {product.title} Category: {product.category} Price: {product.price} V: {product.__v}");
            }

            Console.WriteLine("-----------------Error-----------------");
            List<string> categories2 = new List<string>();
            categories2.Add("Films");
            var getCategory2 = await apiClient.GetCategory(categories2);
            Console.WriteLine(getCategory2.httpStatusCode);
            Console.WriteLine(getCategory2.errorMessage);
            Console.WriteLine(getCategory2.products);
            foreach (var product in getCategory2.products)
            {
                Console.WriteLine($"Id: {product._id} Title: {product.title} Category: {product.category} Price: {product.price} V: {product.__v}");
            }
        }
    }
}
