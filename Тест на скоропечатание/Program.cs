using System.Net.NetworkInformation;
using System.Xml.Linq;
using Тест_на_скоропечатание;

using System.Diagnostics;
using Newtonsoft.Json;


namespace Тест_на_скоропечатание
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool programIsNotOver = true;

            while (programIsNotOver)
            {
                
                User user = new User();
                Console.WriteLine("Введите имя и нажмите Enter");
                user.name = Console.ReadLine();
                //Console.WriteLine(name.name);
                Console.Clear();
                //List<string> text = new List<string>() { "Привет", "hello", "fgr" };
                List<string> text = new List<string>() { "Пять минут назад я дэнсил в своём мерсе, я видел твою тачку это просто мерзость, пять минут назад как с узи пять отверстий, пять минут назад я купил новый перстень ", "Чтобы сдать си шарп, нужно помолиться всем богам в этом крутом мире и начать делать си шарп" , "А брюллы брюллы на мне кружатся и твоя дочь со мной останется,похоже, что я ей понравился, но утром мы с ней попращаемся", "Я не привык к тебе, так что бэйби не привыкай ко мне, если будешь одна скучать, то бэйб заезжай ко мне, я не могу дать тебе любовь, но я могу дать тебе фэйс", "Импорт — Иран, Запахи — чёрный афган, Работа черна, я как нелегал, Автобан, евро скам, стафф Маски, лицо, с братаном забирай всё, масленый dope, маргинал, Здесь навсегда, я как дрилл (Каннибал) Стримов Paco Rabanne Лутаю своё, идя по головам 34 — титан Держу оборону, я Рафа Варан Ориентировка постам: Низкий седан, в руке Пакистан" };
                var rand = new Random();
                int tex = rand.Next(0, 4);
                string textvv = text[tex];

                TypeText tt = new TypeText(textvv);
               
                Console.SetCursorPosition(0, 0);

                tt.AskToStart();

                Console.SetCursorPosition(0, 0);

                tt.Start();

                user.SpeedPerMinute(tt.writtenSymbols, tt.resultTime);
                user.SpeedPerSecond(tt.writtenSymbols, tt.writtenSymbols);

                Console.Clear();

                user.Print();

                Thread.Sleep(2000);

                RecordsTable.AddResult(user);

                RecordsTable.ShowResults();

                Console.WriteLine("\nЧтобы сыграть ещё раз, нажмите Enter");

                var key = Console.ReadKey();

                if (key.Key != ConsoleKey.Enter)
                {
                    Environment.Exit(1);
                }
            }
        }
    }
}