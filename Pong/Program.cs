using System;


namespace Pong;

public class Pong
{
    static void Main(string[] args)
    {

        const int fieldLength = 50, fieldWidth = 15;
        const char fieldTile = '#';
        string line = string.Concat(Enumerable.Repeat(fieldTile, fieldLength));

        const int racketLength = fieldWidth / 4;
        const char racketTile = '|';

        int leftRacketHeight = 0;
        int rightRacketHeight = 0;

        int ballX = fieldLength / 2;
        int ballY = fieldWidth / 2;
        const char ballTile = 'o';

        bool isBallGoingDown = true;
        bool isBallGoingRight = true;
        
        
        
        while (true)
        {
            Console.SetCursorPosition(0,0);
            Console.WriteLine(line);
            
            Console.SetCursorPosition(0, fieldWidth);
            Console.WriteLine(line);

            for (int i = 0; i < racketLength; i++)
            {
                Console.SetCursorPosition(0, i + 1 + leftRacketHeight);
                Console.WriteLine(racketTile);
                Console.SetCursorPosition(fieldLength - 1, i + 1 + rightRacketHeight);
                Console.WriteLine(racketTile);
            }

            while (!Console.KeyAvailable)
            {
                
            }

            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.UpArrow:
                    if (rightRacketHeight > 0)
                    {
                        rightRacketHeight--;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (rightRacketHeight < fieldWidth - racketLength - 1)
                    {
                        rightRacketHeight++;
                    }
                    break;
                case ConsoleKey.W:
                    if (leftRacketHeight > 0)
                    {
                        leftRacketHeight--;
                    }
                    break;
                case ConsoleKey.S:
                    if (leftRacketHeight < fieldWidth - racketLength - 1)
                    {
                        leftRacketHeight++;
                    }
                    break;
            }
            for (int i = 1; i < fieldWidth; i++)
            {
                Console.SetCursorPosition(0, i );
                Console.WriteLine(" ");
                Console.SetCursorPosition(fieldLength - 1, i );
                Console.WriteLine(" ");
            }
        }



        
    }
}