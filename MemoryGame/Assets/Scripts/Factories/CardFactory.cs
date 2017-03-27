using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Interfaces;
using Assets.Scripts.Models;
using Assets.Scripts.Unity;

namespace Assets.Scripts.Factories
{
    public class CardFactory
    {
        private const float cardX = 60;
        private const float cardY = 83;
        private const float cardSpace = 15;

        // init script
        private static List<Card> GetCards(int numCards)
        {
            //TODO: do it right

            Dictionary<int, string> dict = new Dictionary<int, string>();
            dict.Add(1, "one");
            dict.Add(2, "two");
            dict.Add(3, "three");
            dict.Add(4, "four");
            dict.Add(5, "five");
            dict.Add(6, "six");
            dict.Add(7, "seven");
            dict.Add(8, "eight");
            dict.Add(9, "nine");
            dict.Add(10, "ten");
            dict.Add(11, "eleven");
            dict.Add(12, "twelve");
            dict.Add(13, "threeteen");
            dict.Add(14, "fourteen");
            dict.Add(15, "fifteen");

            List<Card> Cards = new List<Card>();

            int idCounter = 1;
            for (int i = 1; i <= numCards / 2; i++)
            {
                Cards.Add(new Card(idCounter, dict[i].ToUpper(), dict[i].ToLower(), new CardUnityBehaviour()));
                idCounter++;
                Cards.Add(new Card(idCounter, dict[i].ToUpper(), dict[i].ToLower(), new CardUnityBehaviour()));
                idCounter++;
            }

            return Cards;
        }

        public static List<Card> DrawCards(int numCards, float cardFieldX, float cardFieldY)
        {
            List<Card> cards = GetCards(numCards);
            cards.Shuffle();

            

            //foreach (Card card in cards)
            //{
            //    card.Draw(x,y,z);
            //    x += 60 + 30;
            //}

            int numX = 0;
            int numY = numCards;

            int tempNumX = numX;
            //int tempNumY = numY;


            while ((tempNumX + 1) <= (numY))
            {
                tempNumX++;
                if (numCards % tempNumX == 0)
                {
                    numX = tempNumX;
                    numY = numCards / tempNumX;
                }

                if (tempNumX == 3 && numCards % tempNumX != 0)
                {
                    numX = tempNumX;
                    numY = numCards/tempNumX + 1;
                    break;
                }
                else if (tempNumX == 3)
                {
                    break;
                }
            }

            if (numX < numY)
            {
                tempNumX = numX;
                numX = numY;
                numY = tempNumX;
            }

            float firstPointX = (cardFieldX - (numX*cardX + (numX - 1)*cardSpace))/2;
            float firstPointY = -(cardFieldY - (numY * cardY + (numY - 1) * cardSpace)) / 2;
            float firstPointZ = 0;

            int cardNum = 0;
            for (int i = 0; i < numY; i++)
            {
                for (int j = 0; j < numX; j++)
                {
                    if (cardNum < cards.Count)
                    {
                        cards[cardNum].Draw(firstPointX, firstPointY, firstPointZ);
                        firstPointX += cardX + cardSpace;
                        cardNum++;
                    }
                }
                firstPointX = (cardFieldX - (numX * cardX + (numX - 1) * cardSpace)) / 2;
                firstPointY -= cardY + cardSpace;
            }

            //int x = 120;
            //int y = 0;
            //int z = 0;
            //for (int i = 0; i < 2; i++)
            //{
            //    for (int j = 0; j < 6; j++)
            //    {
            //        cards[cardNum].Draw(x, y, z);
            //        x += 60 + 40;
            //        cardNum++;
            //    }
            //    x = 120;
            //    y = -83 - 40;
            //}

            return cards;
        }
    }
}
