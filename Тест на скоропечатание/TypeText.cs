using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Тест_на_скоропечатание
{
    public class TypeText
    {
       public string text;

        public int writtenSymbols;

        public int resultTime;

       public TypeText(string text)
        {
            this.text = text;
            this.writtenSymbols = 0;
            this.resultTime = 0;
        }
        
        public void AskToStart()
        {
            while(true)
            {
                Console.Clear();
                Console.WriteLine("\nЧтобы начать, нажмите Enter");
                
                var key = Console.ReadKey();

                if (key.Key == ConsoleKey.Enter)
                {
                    break;
                }
            }
        }
        public void Start()
        {
            Stopwatch stopWatch = new Stopwatch();

            bool timeIsNotOver = true;

            Thread thread = new Thread(_ =>
            {
                stopWatch.Start();
                TimeSpan ts;

                while (timeIsNotOver)
                {
                    ts = stopWatch.Elapsed;

                    var (prevLeft, prevTop) = Console.GetCursorPosition();

                    Console.SetCursorPosition(left: 0, top: 15);
                    Console.Write("{0:00}", 60 - ts.Seconds);
                    Console.SetCursorPosition(prevLeft, prevTop);

                    Thread.Sleep(1000);


                    if (ts.Seconds >= 60)
                    {
                        Console.Clear();
                        Console.WriteLine("Time is over!");
                        timeIsNotOver = false;
                        stopWatch.Stop();

                        //mainThread.Abort();

                        //TimeSpan takenTime = stopWatch.Elapsed;
                        //user.SpeedPerMinute(i, takenTime.Seconds);
                        //user.SpeedPerSecond(i, takenTime.Seconds);

                        //Console.Clear();

                        //user.Print();

                        //Thread.Sleep(2000);
                        //user.SaveResult("../../../Results.json");

                        //User.ShowAllResults("../../../Results.json");


                    }
                }
            });
            thread.Start();

            Console.Clear();
            Console.WriteLine(this.text);
            int i = 0;
           

            while (i < this.text.Length && timeIsNotOver)
            {
                char c = Console.ReadKey(true).KeyChar;
                if (c == this.text[i])
                {
                    i++;
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.Write(c);
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            // i достиг значение lenght 
            stopWatch.Stop();
            TimeSpan takenTime = stopWatch.Elapsed;

            this.writtenSymbols = i;
            this.resultTime = takenTime.Seconds;

            Console.Clear();
        }

    }
}
