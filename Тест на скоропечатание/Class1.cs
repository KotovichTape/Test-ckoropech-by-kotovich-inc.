using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Тест_на_скоропечатание
{
    public class User
    {
        public string name;
        public int speedPerMinute;
        public int speedPerSecond;

        public void SpeedPerMinute(int countSigns, int countSeconds)
        {
            this.speedPerMinute = countSigns / countSeconds * 60;
        }
        public void SpeedPerSecond(int countSigns, int countSeconds)
        {

            this.speedPerSecond = countSigns / countSeconds;
        }
        
        
        public void Print()
        {
            var result = $"{this.name} Симв/мин = {this.speedPerMinute}. Симв/сек = {this.speedPerSecond}";

            Console.WriteLine(result);
        }
    }
}
