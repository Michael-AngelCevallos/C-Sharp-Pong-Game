﻿using System;
using System.Diagnostics.Metrics;


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

        int leftPlayerPoints = 0;
        int rightPlayerPoints = 0;

        int scoreboardX = fieldLength / 2 - 2;
        int scoreboardY = fieldWidth + 3;
        
        
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
                Console.SetCursorPosition(ballX,ballY);
                Console.WriteLine(ballTile);
                Thread.Sleep(100);

                Console.SetCursorPosition(ballX,ballY);
                Console.WriteLine(' ');
                
                if (isBallGoingDown)
                {
                    ballY++;
                }
                else
                {
                    ballY--;
                }

                if (isBallGoingRight)
                {
                    ballX++;
                }
                else
                {
                    ballX--;
                }
                
                // Makes Ball Bounce
                if (ballY == 1 || ballY == fieldWidth - 1)
                {
                    isBallGoingDown = !isBallGoingDown;
                }

                if (ballX == 1)
                {
                    if (ballY >= leftRacketHeight + 1 && ballY <= leftRacketHeight + racketLength)
                    {
                        isBallGoingRight = !isBallGoingRight;
                    }
                    else
                    {
                        rightPlayerPoints++;
                        ballY = fieldWidth / 2;
                        ballX = fieldLength / 2;
                        Console.SetCursorPosition(scoreboardX, scoreboardY);
                        Console.WriteLine($"{leftPlayerPoints} | {rightPlayerPoints}");

                        if (rightPlayerPoints == 10)
                        {
                            goto outer;
                        }
                    }
                }
                if (ballX == fieldLength - 2)
                {
                    if (ballY >= rightRacketHeight + 1 && ballY <= rightRacketHeight + racketLength)
                    {
                        isBallGoingRight = !isBallGoingRight;
                    }
                    else
                    {
                        leftPlayerPoints++;
                        ballY = fieldWidth / 2;
                        ballX = fieldLength / 2;
                        Console.SetCursorPosition(scoreboardX, scoreboardY);
                        Console.WriteLine($"{leftPlayerPoints} | {rightPlayerPoints}");
                        
                        if (leftPlayerPoints == 10)
                        {
                            goto outer;
                        }
                    }
                }
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
        outer: ;
        Console.Clear();
        Console.WriteLine();
        Console.SetCursorPosition(0,0);
        
        if (rightPlayerPoints  == 10)
        {
            Console.WriteLine("Right Player Won!");
        }
        elses
        {
            Console.WriteLine("Left Player Won!");
        }


    }
}