using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Тест_на_скоропечатание
{
    static public class RecordsTable
    {
        static private string filePath = "../../../Results.json";
        
        static public void ShowResults()
        {
            string readed_text = File.ReadAllText(filePath);

            List<User> list = new List<User>();

            list = JsonConvert.DeserializeObject<List<User>>(readed_text);

            //list.Sort();


            Console.Clear();
            Console.WriteLine("         Результаты");
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("Имя        Символы: в минуту     в секунду    ");

            foreach(var user in list)
            {
                user.Print();
            }
            
        }

        static public void AddResult(User player)
        {
            string readed_text = File.ReadAllText(filePath);

            List<User> list = new List<User>();

            list = JsonConvert.DeserializeObject<List<User>>(readed_text);

            bool userFound = false;

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].name == player.name)
                {
                    userFound = true;
                    if (list[i].speedPerSecond < player.speedPerSecond)
                    {
                        list[i].speedPerMinute = player.speedPerMinute;
                        list[i].speedPerSecond = player.speedPerSecond;
                    }
                }
            }

            if (!userFound)
            {
                list.Add(player);
            }

            string json = JsonConvert.SerializeObject(list);

            File.WriteAllText($"{filePath}", json);
        }


    }
}
