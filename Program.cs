using System;
using System.Threading;

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

            while(true)
            {
                gol.Draw();
                gol.NextGeneration();
                Thread.Sleep(sleepTime);
            }
        }
    }
}
