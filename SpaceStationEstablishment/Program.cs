using System;
using System.Linq;

namespace SpaceStationEstablishment
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int playerX = 0, playerY = 0;
            int starPower = 0;
            int holeOneX = 0, holeOneY = 0;
            int holeTwoX = 0, holeTwoY = 0;
            bool isLost = false;
            bool hasBlackHole = false;

            char[,] galaxy = new char[n, n];

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                for (int j = 0; j < n; j++)
                {
                    galaxy[i, j] = input[j];
                    if (galaxy[i, j] == 'S')
                    {
                        playerX = i;
                        playerY = j;
                    }
                    if (galaxy[i, j] == 'O')
                    {
                        if (!hasBlackHole)
                        {
                            holeOneX = i;
                            holeOneY = j;
                        }
                        else
                        {
                            holeTwoX = i;
                            holeTwoY = j;
                        }
                    }


                }
            }

            while (!isLost && starPower < 50)
            {
                string move = Console.ReadLine();
                MoveSpaceship(ref playerX, ref playerY, move);

                // Console.WriteLine($"{playerX} and {playerY}");

                if (playerX < 0 || playerX == n || playerY < 0 || playerY == n)
                {
                    isLost = true;
                    continue;
                }

                if (char.IsDigit(galaxy[playerX, playerY]))
                {
                    starPower = CollectStarPower(playerX, playerY, starPower, galaxy);
                }

                if (galaxy[playerX, playerY] == 'O')
                {
                    SwitchPlacesDueToBlackHole(ref playerX, ref playerY, holeOneX, holeOneY, holeTwoX, holeTwoY, galaxy);
                }
            }

            PrintOutput(starPower, isLost);

        }

        private static void PrintOutput(int starPower, bool isLost)
        {
            if (isLost)
            {
                Console.WriteLine("Bad news, the spaceship went to the void.");
            }
            else if (starPower >= 50)
            {
                Console.WriteLine("Good news! Stephen succeeded in collecting enough star power!");
            }

            Console.WriteLine($"Star power collected: {starPower}");
        }

        private static void SwitchPlacesDueToBlackHole(ref int playerX, ref int playerY, int holeOneX, int holeOneY, int holeTwoX, int holeTwoY, char[,] galaxy)
        {
            galaxy[playerX, playerY] = '-';
            if (playerX == holeOneX && playerY == holeOneY)
            {
                playerX = holeTwoX;
                playerY = holeTwoY;
            }
            else
            {
                playerX = holeOneX;
                playerY = holeOneY;
            }
            galaxy[playerX, playerY] = '-';
        }

        private static int CollectStarPower(int playerX, int playerY, int starPower, char[,] galaxy)
        {
            int add = galaxy[playerX, playerY] - '0';
            starPower += add;
            galaxy[playerX, playerY] = '-';
            return starPower;
        }

        private static void MoveSpaceship(ref int playerX, ref int playerY, string move)
        {
            switch (move)
            {
                case "up":
                    playerX--;
                    break;
                case "down":
                    playerX++;
                    break;
                case "left":
                    playerY--;
                    break;
                case "right":
                    playerY++;
                    break;
            }
        }
    }
}
