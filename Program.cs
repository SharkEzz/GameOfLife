using System;
using System.Threading;
using System.Diagnostics;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            int sleepTime = 100;
            
            if(args.Length != 0)
            {
                sleepTime = int.Parse(args[0]);
            }

            GameOfLife gol = new GameOfLife(60, 250, true);

            /*gol.currentMap[10, 10] = 1;
            gol.currentMap[10, 11] = 1;
            gol.currentMap[10, 12] = 1;
            gol.currentMap[10, 13] = 1;
            gol.currentMap[10, 14] = 1;

            gol.currentMap[12, 10] = 1;
            gol.currentMap[12, 14] = 1;

            gol.currentMap[15, 10] = 1;
            gol.currentMap[15, 11] = 1;
            gol.currentMap[15, 12] = 1;
            gol.currentMap[15, 13] = 1;
            gol.currentMap[15, 14] = 1;*/

            Console.Clear();
            Console.CursorVisible = false;

            string time = DateTime.Now.ToString("ss");
            int iterations = 0;

            while(true)
            {
                gol.Draw();
                gol.NextGeneration();
                if(DateTime.Now.ToString("ss") == time)
                {
                    iterations++;
                }
                else
                {
                    Console.WriteLine("\n\nFPS : {0}", iterations);
                    iterations = 0;
                }
                time = DateTime.Now.ToString("ss");
                Thread.Sleep(sleepTime);
            }
        }
    }
}
