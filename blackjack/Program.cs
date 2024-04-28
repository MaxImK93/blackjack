using System;

namespace blackjack
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string playerName;
            int playerCount = 0;
            int dilerCount = 0;

            Deck gameDeck = new Deck();
            Input input = new Input();

            // gameDeck.PrintDeck();

            playerName = input.SetName();

            Units player = new Units(playerName); ;
            Units diler = new Units("Diler");

            input.MainGame(playerCount, dilerCount, playerName);

            gameDeck.FirstDraw(ref playerCount);

            while (playerCount < 21)
            {

                input.CurrentCount(playerName, playerCount);

                if (!input.NextorEnd())
                {
                    break;
                }

                gameDeck.NextDraw(ref playerCount);
            }

            input.GameOver(playerCount, dilerCount, playerName);

            gameDeck.FirstDilerDraw(ref dilerCount);

            input.CurrentCount("Diler", dilerCount);

            while (dilerCount < 21)
            {
                if (dilerCount < 17)
                {
                    gameDeck.DilerDraw(ref dilerCount);
                }
                else
                {
                    break;
                }
            }

            input.GameOver(playerCount, dilerCount, playerName);

            input.FinalScore(playerCount, dilerCount, playerName);
        }
    }
}
