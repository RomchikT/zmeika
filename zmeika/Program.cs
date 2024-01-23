namespace zmeika
{
    using System;
    using System.Threading;

    namespace SnakeGame
    {
        class Program
        {
            static int width = 20;
            static int height = 10;
            static int score = 0;
            static int[] xPosition = new int[50];
            static int[] yPosition = new int[50];
            static int fruitX;
            static int fruitY;
            static bool isGameOver = false;
            static Random random = new Random();
            static ConsoleKeyInfo keyInfo;

            enum Direction
            {
                Up,
                Down,
                Left,
                Right
            }
            static Direction direction = Direction.Right;

            static void Main(string[] args)
            {
                Setup();
                while (!isGameOver)
                {
                    Draw();
                    Input();
                    Logic();
                    Thread.Sleep(200);
                }
            }

            static void Setup()
            {
                Console.CursorVisible = false;
                Console.SetWindowSize(width, height);
                Console.SetBufferSize(width, height);
                xPosition[0] = width / 2;
                yPosition[0] = height / 2;
                fruitX = random.Next(0, width);
                fruitY = random.Next(0, height);
            }

            static void Draw()
            {
                Console.Clear();
                Console.SetCursorPosition(fruitX, fruitY);
                Console.Write("@");
                for (int i = 0; i < score + 1; i++)
                {
                    Console.SetCursorPosition(xPosition[i], yPosition[i]);
                    if (i == 0)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write("*");
                    }
                }
                DrawBorders();
                Console.SetCursorPosition(0, 0);
                Console.Write("Score: " + score);
            }

            static void DrawBorders()
            {
                for (int i = 0; i < width; i++)
                {
                    Console.SetCursorPosition(i, 0);
                    Console.Write("|");
                    Console.SetCursorPosition(i, height - 1);
                    Console.Write("|");
                }
                for (int i = 0; i < height; i++)
                {
                    Console.SetCursorPosition(0, i);
                    Console.Write("-");
                    Console.SetCursorPosition(width - 1, i);
                    Console.Write("-");
                }
            }

            static void Input()
            {
                if (Console.KeyAvailable)
                {
                    keyInfo = Console.ReadKey();
                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.UpArrow:
                            direction = Direction.Up;
                            break;
                        case ConsoleKey.DownArrow:
                            direction = Direction.Down;
                            break;
                        case ConsoleKey.LeftArrow:
                            direction = Direction.Left;
                            break;
                        case ConsoleKey.RightArrow:
                            direction = Direction.Right;
                            break;
                    }
                }
            }

            static void Logic()
            {
                for (int i = score; i > 0; i--)
                {
                    xPosition[i] = xPosition[i - 1];
                    yPosition[i] = yPosition[i - 1];
                }

                switch (direction)
                {
                    case Direction.Up:
                        yPosition[0]--;
                        break;
                    case Direction.Down:
                        yPosition[0]++;
                        break;
                    case Direction.Left:
                        xPosition[0]--;
                        break;
                    case Direction.Right:
                        xPosition[0]++;
                        break;
                }

                if (xPosition[0] == fruitX && yPosition[0] == fruitY)
                {
                    score++;
                    fruitX = random.Next(0, width);
                    fruitY = random.Next(0, height);
                }

                if (xPosition[0] == 0 || xPosition[0] == width - 1 || yPosition[0] == 0 || yPosition[0] == height - 1)
                {
                    isGameOver = true;
                }

                for (int i = 1; i < score + 1; i++)
                {
                    if (xPosition[i] == xPosition[0] && yPosition[i] == yPosition[0])
                    {
                        isGameOver = true;
                    }
                }
            }
        }
    }
}