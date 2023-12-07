using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{  
    class Task
    {
        public double Duration { get; set; }
        public double Score { get; set; }
        public double Ratio
        {
            get
            {
                return (double)Score / Duration;
            }
        }
    }
    class Program
    {

        public List<Task> ProcessTasks(List<Task> tasks, double time)
        {
            var sortedTasks = tasks.OrderByDescending(task => task.Ratio);
            double maxValue = 0;
            var selectedTasks = new List<Task>();

            for (int i = 0; i < sortedTasks.Count(); i++)
            {
                if (sortedTasks.ElementAt(i).Duration <= time)
                {
                    maxValue += sortedTasks.ElementAt(i).Score;
                    selectedTasks.Add(sortedTasks.ElementAt(i));
                    time -= sortedTasks.ElementAt(i).Duration;
                }
            }

            return selectedTasks;
        }

        static void Main()
        {

            // Перевірочний кейс 1
            var tasks1 = new List<Task>
            {
                new Task { Score = 1, Duration = 1 },
                new Task { Score = 2, Duration = 3 },
                new Task { Score = 3, Duration = 4},
            };
            double  time1 = 7;
            Program p = new Program();
            List<Task> selectedTasks1 = p.ProcessTasks(tasks1, time1);

            var tasks2 = new List<Task>
            {
                new Task { Score = 1, Duration = 1 },
                new Task { Score = 3, Duration = 2 },
                new Task { Score = 4, Duration = 3},
            };
            double time2 = 5;
            List<Task> selectedTasks2 = p.ProcessTasks(tasks2, time2);


            Console.WriteLine("(case1)Selected tasks:");
            foreach (var task in selectedTasks1)
            {
                Console.WriteLine($"Task Duration: {task.Duration}, Task Score: {task.Score}");
            }

            Console.WriteLine("(case2)Selected tasks:");
            foreach (var task in selectedTasks2)
            {
                Console.WriteLine($"Task Duration: {task.Duration}, Task Score: {task.Score}");
            }
            Console.ReadKey();
        }
    }

}
