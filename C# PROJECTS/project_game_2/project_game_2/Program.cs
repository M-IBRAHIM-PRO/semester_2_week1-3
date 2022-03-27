using System;
using System.IO;
using System.Threading;
using EZInput;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_game_2
{
    class player_information
    {
        public string x1;
        public int playerX = 23;
        public int playerY = 31;
    }
    internal class Program
    {
        static int score = 0;
       
        static void Main(string[] args)
        {
            char[,] maze = new char[25, 58];
           
            player_information record = new player_information();
            
            // Enemy 1 specific movement
            char previous1 = ' ';
            int Enemy1X = 21;
            int Enemy1Y = 14;
            string Enemy1direction = "right";
            
            // Enemy 3 Random movement
            char previous2 = ' ';
            int Enemy2X = 19;
            int Enemy2Y = 25;
            
            readData(maze);
            start_header();
            Console.SetCursorPosition(5,9);
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.Clear();
            print_maze(maze);

            Console.SetCursorPosition(record.playerY,record.playerX);
            Console.Write("P");

            bool gameRunning;
            while (true)
            {
                Thread.Sleep(50);
                printScore();
                gameRunning = moveEnemyRandom(maze,ref Enemy1X,ref Enemy1Y,ref previous1);
                if (!gameRunning)
                {
                    over_header();
                    break;
                }
                gameRunning = moveEnemyRandom(maze,ref Enemy2X,ref Enemy2Y,ref previous2);
                if (!gameRunning)
                {
                    over_header();
                    break;
                }
                if (Keyboard.IsKeyPressed(Key.UpArrow))
                {
                    moveplayerUp(maze, ref record.playerX, ref record.playerY);
                }
                if (Keyboard.IsKeyPressed(Key.DownArrow))
                {
                    moveplayerDown(maze, ref record.playerX, ref record.playerY);
                }
                if (Keyboard.IsKeyPressed(Key.LeftArrow))
                {
                    moveplayerLeft(maze, ref record.playerX, ref record.playerY);
                }
                if (Keyboard.IsKeyPressed(Key.RightArrow))
                {
                    moveplayerRight(maze, ref record.playerX, ref record.playerY);
                }
                if (Keyboard.IsKeyPressed(Key.Escape))
                {
                    break;
                }
            }
        }
        //___________________FUNCTIONS_________________________

        static void start_header()
        {
           Console.Clear();
           Console.WriteLine("  ____________________________________  " );
           Console.WriteLine(" |  %%%%%     %%     %%    %%  %%%%%  | " );
           Console.WriteLine(" |  %%      %%  %%   %% %% %%  %%___  | " );
           Console.WriteLine(" |  %%  %%  %%%%%%%  %% %% %%  %%     | " );
           Console.WriteLine(" |  %%%%%   %%   %%  %%    %%  %%%%%  | " );
           Console.WriteLine(" |____________________________________| " );
           Console.WriteLine();
           Console.WriteLine();
        }
        static void over_header()
        {
            Console.Clear();
            Console.WriteLine("  ____________________________________________" );
            Console.WriteLine(" |  %%%%%  %%      %%  %%%%%  %%%%%    %%%%%  | " );
            Console.WriteLine(" |  %% %%   %%    %%   %%__   %%   %%  %%___  | " );
            Console.WriteLine(" |  %% %%    %%  %%    %%     %% %%    %%     | " );
            Console.WriteLine(" |  %%%%%      %%      %%%%%  %%   %%  %%%%%  | " );
            Console.WriteLine(" |____________________________________________| " );
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine(" SCORE : " + score);
            Console.WriteLine();

            score = 0; // resett score;
            //life = 3;    // reset life.
            Console.ReadKey();
            
        }
        static void print_maze(char[,] maze)
        {
            for (int i = 0; i < maze.GetLength(0); i++)
            {
                for (int j = 0; j < maze.GetLength(1); j++)
                {
                    Console.Write(maze[i, j]);
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
        static void readData(char[,] maze)
        {
            string path = "C:\\C# PROJECTS\\gameproject\\maze.txt";
            StreamReader fp = new StreamReader(path);
            string record;
            int row = 0;
            while ((record = fp.ReadLine()) != null)
            {
                for (int x = 0; x < 58; x++)
                {
                    maze[row, x] = record[x];
                }

                row++;
            }

            fp.Close();
        }
        static void printScore()
        {
            Console.SetCursorPosition(70, 6);
            Console.WriteLine("Score: " + score);
        }
        static void update_score()
        {
            score++;
        }
        //________________________PLAYER______________________________
        static void moveplayerUp(char[,] maze, ref int playerX, ref int playerY)
        {
            if (maze[playerX - 1, playerY] == ' ')
            {
                maze[playerX, playerY] = ' ';
                Console.SetCursorPosition(playerY, playerX);
                Console.Write(" ");
                playerX = playerX - 1;

                Console.SetCursorPosition(playerY, playerX);
                maze[playerX, playerY] = 'P';
                Console.Write("P");
            }
        }
        static void moveplayerDown(char[,] maze, ref int playerX, ref int playerY)
        {
            if (maze[playerX + 1, playerY] == ' ' || maze[playerX + 1, playerY] == '$')
            {
                maze[playerX, playerY] = ' ';
                Console.SetCursorPosition(playerY, playerX);
                Console.Write(" ");
                playerX = playerX + 1;

                Console.SetCursorPosition(playerY, playerX);
                maze[playerX, playerY] = 'P';
                Console.Write("P");
            }
        }

        static void moveplayerLeft(char[,] maze, ref int playerX, ref int playerY)
        {
            if (maze[playerX, playerY - 1] == ' ' || maze[playerX, playerY - 1] == '$')
            {
                if (maze[playerX, playerY - 1] == '$')
                {
                    update_score();
                }

                maze[playerX, playerY] = ' ';
                Console.SetCursorPosition(playerY, playerX);
                Console.Write(" ");
                playerY = playerY - 1;

                Console.SetCursorPosition(playerY, playerX);
                maze[playerX, playerY] = 'P';
                Console.Write("P");

            }
        }

        static void moveplayerRight(char[,] maze, ref int playerX, ref int playerY)
        {
            if (maze[playerX, playerY + 1] == ' ' || maze[playerX, playerY + 1] == '$')
            {
                if (maze[playerX, playerY] == '$')
                {
                    update_score();
                }

                maze[playerX, playerY] = ' ';
                Console.SetCursorPosition(playerY, playerX);
                Console.Write(" ");
                playerY = playerY + 1;

                Console.SetCursorPosition(playerY, playerX);
                maze[playerX, playerY] = 'P';
                Console.Write("P");
            }
        }

        //_________________________Enemy______________________________________
        static int EnemyDirection()
        {
            Random r = new Random();
            int value = r.Next(4);
            return value;
        }
        static bool moveEnemyRandom(char[,] maze, ref int X, ref int Y, ref char previous)
        {
            if (maze[X, Y - 1] == 'P' || maze[X, Y + 1] == 'P')
            {
                return false;
            }
            int value = EnemyDirection();
            if (value == 0 || value == 1)
            {
                if (maze[X, Y - 1] == ' ' || maze[X, Y - 1] == '$' || maze[X, Y - 1] == 'P')
                {
                    maze[X, Y] = previous;
                    Console.SetCursorPosition(Y, X);
                    Console.Write(previous);

                    Y = Y - 1;
                    previous = maze[X, Y];
                    Console.SetCursorPosition(Y, X);
                    Console.Write('&');
                }
            }
            else if (value == 2 || value == 3)
            {
                if (maze[X, Y + 1] == ' ' || maze[X, Y + 1] == '$' || maze[X, Y + 1] == 'P')
                {
                    maze[X, Y] = previous;
                    Console.SetCursorPosition(Y, X);
                    Console.Write(previous);
                    Y = Y + 1;
                    previous = maze[X, Y];
                    Console.SetCursorPosition(Y, X);
                    Console.Write('&');
                }
            }
            return true;
        }

    }
}
