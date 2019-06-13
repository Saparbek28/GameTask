using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace TaskThreadHW
{
    class Program
    {
        static void Main(string[] args)
        {
            Task task = new Task(() => {
                WebRequest request = WebRequest.Create("https://omgvamp-hearthstone-v1.p.rapidapi.com/cards/Deathwing,%20Dragonlord");
                request.Headers.Add("X-RapidAPI-Host", "omgvamp-hearthstone-v1.p.rapidapi.com");
                request.Headers.Add("X-RapidAPI-Key", "7be6bad869msh4a1275c8b247fb1p1e2dfdjsna3d2728f7718");
                WebResponse response = request.GetResponse();
                using (var stream = response.GetResponseStream())
                {
                    using (var reader = new StreamReader(stream))
                    {
                        string json = reader.ReadToEnd();
                        List<Info> info = JsonConvert.DeserializeObject<List<Info>>(json);
                        Console.WriteLine($"attack = {info[0].Attack}");
                        Console.WriteLine($"HP = {info[0].Health}");
                        Console.WriteLine($"Price = {info[0].Cost}");
                        Console.WriteLine($"Name = {info[0].Name}");
                        Console.WriteLine($"Rarity = {info[0].Rarity}");
                        Console.WriteLine($"Type = {info[0].Type}");
                        Console.WriteLine($"Race = {info[0].Race}");
                    }
                }
            });

            Console.WriteLine("////////////////////////////////////////////////////////");

            Task tasks = new Task(() => {
                WebRequest request = WebRequest.Create("https://omgvamp-hearthstone-v1.p.rapidapi.com/cards/Golemagg");
                request.Headers.Add("X-RapidAPI-Host", "omgvamp-hearthstone-v1.p.rapidapi.com");
                request.Headers.Add("X-RapidAPI-Key", "7be6bad869msh4a1275c8b247fb1p1e2dfdjsna3d2728f7718");
                WebResponse response = request.GetResponse();
                using (var stream = response.GetResponseStream())
                {
                    using (var reader = new StreamReader(stream))
                    {
                        string json = reader.ReadToEnd();
                        List<Info> info = JsonConvert.DeserializeObject<List<Info>>(json);
                        Console.WriteLine($"attack = {info[0].Attack}");
                        Console.WriteLine($"HP = {info[0].Health}");
                        Console.WriteLine($"Price = {info[0].Cost}");
                        Console.WriteLine($"Name = {info[0].Name}");
                        Console.WriteLine($"Rarity = {info[0].Rarity}");
                        Console.WriteLine($"Type = {info[0].Type}");
                        Console.WriteLine($"Race = {info[0].Race}");
                    }
                }
            });

            task.Start();
            tasks.Start();
            Console.ReadLine();
        }
    }
}
