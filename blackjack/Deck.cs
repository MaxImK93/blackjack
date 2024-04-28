using System;
using System.Collections.Generic;

namespace blackjack
{
    public class Deck
    {
        private Dictionary<string, int> deck = new Dictionary<string, int>();
        

        public Deck()
        {
            // Массив названий карт, где картинки имеют одинаковое значение 10
            string[] names = { "Туз", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Валет", "Дама", "Король" };
            int[] values = { 11, 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10 };  // Соответствующие значения

            // Добавляем каждую карту 4 раза (по числу мастей)
            for (int i = 0; i < names.Length; i++)
            {
                deck.Add(names[i] + " ♠", values[i]);  // Пики
                deck.Add(names[i] + " ♥", values[i]);  // Червы
                deck.Add(names[i] + " ♦", values[i]);  // Бубны
                deck.Add(names[i] + " ♣", values[i]);  // Крести
            }

        }

        // Метод для вывода всех карт в колоде
        public void PrintDeck()
        {
            foreach (var card in deck)
            {
                Console.WriteLine($"{card.Key}: {card.Value}");
            }
        }

        public KeyValuePair<string, int> DrawCard()
        {
            if (deck.Count > 0)
            {
                Random rand = new Random();
                List<string> keyList = new List<string>(deck.Keys);
                string randomKey = keyList[rand.Next(keyList.Count -1)];
                int cardValue = deck[randomKey];
                deck.Remove(randomKey);
                return new KeyValuePair<string, int>(randomKey, cardValue);
            }
            else
            {
                throw new InvalidOperationException("Колода пуста");

            }
        }

        public void FirstDraw(ref int playerCount)
        {
            var card1 = DrawCard();
            playerCount += card1.Value;

            var card2 = DrawCard();
            playerCount += card2.Value;

            Console.WriteLine($"Вытянуты карты: \n" +
                $" {card1.Key}, очки: {card1.Value} \n " +
                $"{card2.Key}, очки: {card2.Value} \n ");

        }

        public void NextDraw(ref int playerCount)
        {
            var card = DrawCard();
            playerCount += card.Value;
            Console.WriteLine($"Вы вытянутли {card.Value} \n");
        }

        public void FirstDilerDraw(ref int dilerCountt)
        {
            var card1 = DrawCard();
            dilerCountt += card1.Value;

            var card2 = DrawCard();
            dilerCountt += card2.Value;

            Console.WriteLine($"У дилера вытянуты карты: \n" +
                $" {card1.Key}, очки: {card1.Value} \n " +
                $"{card2.Key}, очки: {card2.Value} \n ");

        }

        public void DilerDraw(ref int dilerCount)
        {
            var card = DrawCard();
            dilerCount += card.Value;
            Console.WriteLine($"Diler вытянутл {card.Value} \n");
        }

    }
}
