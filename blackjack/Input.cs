﻿using System;
namespace blackjack
{
    public class Input
    {
        private string _playerName; 

        public Input()
        {

        }

        public string SetName()
        {
            Console.Write($"Введите Ваше имя: {_playerName} ");

            _playerName = Console.ReadLine();

            return _playerName;

        }

        public void MainGame(int playerCount, int dilerCount, string playerName)
        {

            Console.WriteLine($"У {playerName} сейчас: {playerCount} очков");
            Console.WriteLine($"У соперника сейчас: {dilerCount} очков");

            Console.WriteLine("Нажмите любую клавишу, чтобы начать раздачу");
            Console.ReadKey();
        }

        public void CurrentCount(string playerName, int playerCount)
        {
            Console.WriteLine($"У {playerName} сейчас: {playerCount} очков");
        }

        public bool NextorEnd()
        {
            Console.WriteLine("Нажмите 'D' чтобы вытянуть карту или 'N' чтобы завершить ход");

            while (true)
            {
                var key = Console.ReadKey().Key;
                Console.WriteLine();

                if (key == ConsoleKey.N)
                {
                    // Возвращаем false, если игрок решил завершить ход
                    return false;
                }
                else if (key == ConsoleKey.D)
                {
                    // Возвращаем true, если игрок решил продолжить
                    return true;
                }
                else
                {
                    Console.WriteLine("Нажата неподходящая клавиша, попробуйте снова.");
                    continue;
                }
            }
        }


        public void GameOver(int playerCount, int dilerCount, string playerName)
        {
            if (playerCount > 21)
            {
                Console.WriteLine("Победил Diler");
                Environment.Exit(0);

            }
            else if (dilerCount > 21)
            {
                Console.WriteLine($"Победил {playerName}");
                Environment.Exit(0);
            }

            
        }
    }
}
