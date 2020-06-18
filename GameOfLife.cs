using System;

namespace GameOfLife
{
    class GameOfLife
    {
        #region variables
        public readonly int mapWidth;
        public readonly int mapHeight;

        public readonly bool generateRandomMap;

        private uint currentGeneration = 0;

        public int[,] currentMap;
        public int[,] newMap;
        #endregion

        public GameOfLife(int width, int height, bool generateRandomMap)
        {
            mapWidth = width;
            mapHeight = height;
            this.generateRandomMap = generateRandomMap;

            GenerateMap();
        }

        public void NextGeneration()
        {
            for(int x = 0; x < mapWidth; x++)
            {
                for(int y = 0; y < mapHeight; y++)
                {
                    int aliveNeighbours = CalculateAliveNeighbours(x, y);

                    if(currentMap[x, y] == 1 && aliveNeighbours < 2)
                        newMap[x, y] = 0;
                    else if(currentMap[x, y] == 1 && aliveNeighbours > 3)
                        newMap[x, y] = 0;
                    else if(currentMap[x, y] == 0 && aliveNeighbours == 3)
                        newMap[x, y] = 1;
                    else
                        newMap[x, y] = currentMap[x, y];
                }
            }

            TransferNewToCurrentMap();
            currentGeneration++;
        }

        public void Draw()
        {
            string buffer = "";

            for(int x = 0; x < mapWidth; x++)
            {
                for(int y = 0; y < mapHeight; y++)
                {
                    if(currentMap[x, y] == 0)
                    {
                        buffer += " ";
                    }
                    else
                    {
                        buffer += "*";
                    }
                }
                buffer += "\n";
            }

            Console.SetCursorPosition(0, 0);
            Console.WriteLine("Génération : {0}", currentGeneration);

            Console.SetCursorPosition(0, 2);
            for(int i = 0; i < mapHeight; i++)
            {
                Console.Write('-');
            }
            Console.WriteLine();
            Console.Write(buffer);
            for(int i = 0; i < mapHeight; i++)
            {
                Console.Write('-');
            }
        }

        #region private

        private void GenerateMap()
        {
            currentMap = new int[mapWidth, mapHeight];
            newMap = new int[mapWidth, mapHeight];

            Random random = new Random();
            for(int x = 0; x < mapWidth; x++)
            {
                for(int y = 0; y < mapHeight; y++)
                {
                    if(generateRandomMap)
                    {
                        if(random.Next(1, 101) < 70)
                        {
                            currentMap[x, y] = 0;
                        }
                        else
                        {
                            currentMap[x, y] = 1;
                        }
                    }
                    else
                    {
                        currentMap[x, y] = 0;
                    }
                }
            }
        }

        private void TransferNewToCurrentMap()
        {
            for(int x = 0; x < mapWidth; x++)
            {
                for(int y = 0; y < mapHeight; y++)
                {
                    currentMap[x, y] = newMap[x, y];
                }
            }
        }

        private int CalculateAliveNeighbours(int x, int y)
        {
            int alive = 0;

            for(int i = -1; i <= 1; i++)
            {
                for(int j = -1; j <= 1; j++)
                {
                    if(x + i < 0 || x + i >= mapWidth)
                        continue;
                    if(y + j < 0 || y + j >= mapHeight)
                        continue;
                    if(x + i == x && y + j == y)
                        continue;

                    alive += currentMap[x + i, y + j];
                }
            }

            return alive;
        }

        #endregion
        
    }
}