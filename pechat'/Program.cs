
using System.Diagnostics;
using System.Drawing;

namespace Hz
{
    internal class Program
    {
        static int i = 0;
        private static int tscore = 0;
        private static int fscore = 0;

        private static bool timerSet = true;

        static void Main()
        {
            Console.CursorVisible = false;
            string txt = "Текст-текст";
            List<char> text = new(txt);
            int count = text.Count;

            Console.SetCursorPosition(37, 12);
            Console.WriteLine("-------------------------------------------");
            Console.SetCursorPosition(37, 13);
            Console.WriteLine("|");
            Console.SetCursorPosition(37, 14);
            Console.WriteLine("-------------------------------------------");
            Console.SetCursorPosition(79, 13);
            Console.WriteLine("|");

            Timer();

            Thread thread = new Thread(new ThreadStart(Panel));
            thread.Start();


            Thread.Sleep(10);
            for (int i = 0; i < (count) && timerSet != false; i++)
            {

                Console.SetCursorPosition(38, 13);
                Write(text);
            }
            Console.SetCursorPosition(38, 13);
            Console.WriteLine("                  Финал.                   ");
            Console.ReadKey();
            Main();
        }

        private static void Write(List<char> text)
        {
            for (int i = 0; i < 41; i++)
            {
                if (i >= text.Count)
                {
                    Console.Write(" ");
                }
                else
                {
                    Console.Write(text[i]);
                }
            }


            Console.WriteLine();
            IsItRight(text);
            text.RemoveAt(0);
        }

        private static void IsItRight(List<char> text)
        {
            var key = Console.ReadKey(true);
            while (key.KeyChar != text[i])
            {
                key = Console.ReadKey(true);
                fscore += 1;
            }

            tscore += 1;
        }

        private static void Panel()
        {
            while (timerSet)
            {
                Console.SetCursorPosition(0, 27);
                AnsiConsole.Write(new BreakdownChart()
                    .AddItem("", fscore, Color.Red));
                Thread.Sleep(327);
            }
        }

        private static void Timer()
        {
            Thread t = new Thread(_ =>
            {
                Stopwatch stopwatch = Stopwatch.StartNew();
                while (stopwatch.ElapsedMilliseconds / 1000 < 60)
                {
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine(stopwatch.ElapsedMilliseconds / 1000);
                    Thread.Sleep(6000);
                }

                timerSet = false;
                Console.SetCursorPosition(38, 13);
                Console.WriteLine("                  Финал.                   ");
            });

            t.Start();
        }
    }

    internal class BreakdownChart
    {
        public BreakdownChart()
        {
        }

        internal object AddItem(string v, int fscore, Color red)
        {
            throw new NotImplementedException();
        }

        internal object Width(int v)
        {
            throw new NotImplementedException();
        }
    }
}