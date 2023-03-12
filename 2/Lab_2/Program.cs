using Humanizer;
using Newtonsoft.Json;
using RestSharp;
using System;
using UnitConversion;

namespace Lab_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Libraries libs = new Libraries();
            libs.Start();
        }


        class Libraries
        {
            public void NLogLibrary()
            {
                Console.WriteLine("-NLog library-");
                var logger = NLog.LogManager.GetCurrentClassLogger();
                logger.Info(" App used by {username} !", "Nikolas Ochkovsky");
                Console.WriteLine("----------------------------------------------------------------------------------------");
            }
            public void RestAndNewton()
            {
                Console.WriteLine("-RestSharp and Newtonsoft.json-");
                var client = new RestClient("https://randomuser.me/api/?inc=gender,name,nat,email&noinfo");
                var request = new RestRequest();
                var result = client.Get<Object>(request);
                Console.WriteLine(result);
                Console.WriteLine("________________________");
                var data = JsonConvert.DeserializeObject<dynamic>(result.ToString());
                dynamic person = data.results[0];
                Console.WriteLine("Gender: " + person.gender);
                Console.WriteLine("Title: " + person.name.title);
                Console.WriteLine("First name: " + person.name.first);
                Console.WriteLine("Last name: " + person.name.last);
                Console.WriteLine("Email: " + person.email);
                Console.WriteLine("Nationality: " + person.nat);
                Console.WriteLine("----------------------------------------------------------------------------------------");
            }
            public void Humanizer()
            {
                Console.WriteLine("-Humanizer-");
                Console.WriteLine(DateTime.Now.AddDays(-2).Humanize());
                Console.WriteLine(DateTime.Now.AddSeconds(-50).Humanize());
                Console.WriteLine(1984.ToWords());
                Console.WriteLine(3.ToOrdinalWords());
                Console.WriteLine(10.Ordinalize());
                string text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed ut dignissim sapien, at aliquet ligula.";
                Console.WriteLine(text.Truncate(13, "..."));
                Console.WriteLine("----------------------------------------------------------------------------------------");
            }
            public void Conversion()
            {
                Console.WriteLine("-UnitConversion-");
                var kmToYd = new DistanceConverter("km", "yd");
                int km = 186;
                double yd = kmToYd.LeftToRight(km);
                Console.WriteLine(km + " kilometers, its " + Math.Round(yd, 1) + " yards");
            }
            public void Start()
            {
                NLogLibrary();
                RestAndNewton();
                Humanizer();
                Conversion();
                Console.ReadLine();
            }
        }
    }
}