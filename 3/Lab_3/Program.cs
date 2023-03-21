using System;
using System.IO;
using System.Threading;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text;
using Newtonsoft.Json;

namespace Lab_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Files operations = new Files();
            //operations.BackupFile();
            //operations.ShowRequest(); 
            operations.Timer();
            //operations.RewriteFile();
            Console.ReadLine();
        }
    }
    class Files
    {
        private string path = @"C:\repositories\pppi_uni\3\Lab_3\Files";

        public void BackupFile()
        {
            Thread thread = new Thread(() =>
            {
                try
                {
                    File.Copy(path + "\\info.txt", path + "\\info-backup.txt");
                    Console.WriteLine("Backup file created from info.txt to info-backup.txt");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error occurred while copying file: {ex.Message}");
                }
            });
            thread.Start(); 
        }
        public async void ShowRequest()
        {
            using (HttpClient client = new HttpClient())
            {
                string url = "https://randomuser.me/api/?results=5&inc=gender,name,nat,email&noinfo";
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string json = await response.Content.ReadAsStringAsync();
                Console.WriteLine(json);
            }
        }
        public void Timer()
        {
            Console.Write("Type a count of seconds for timer: ");
            int countdown = int.Parse(Console.ReadLine());

            Thread thread = new Thread(() =>
            {
                for (int i = countdown; i > 0; i--)
                {
                    Console.WriteLine(i);
                    Thread.Sleep(1000); // wait for 1 second
                }
                Console.WriteLine("Timer finish");
            });
            thread.Start();
        }
    }
}
