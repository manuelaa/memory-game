using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Interfaces;
using Assets.Scripts.Models;
using Assets.Scripts.Unity;
using UnityEngine;

namespace Assets.Scripts.Factories
{
    public class CardFactory
    {
        private const float cardX = 60;
        private const float cardY = 83;
        private const float cardSpace = 20;

        public static float currentCardX = cardX;
        public static float currentCardY = cardY;
        public static float currentCardSpace = cardSpace;
        public static int currentNumX = 0;
        public static int currentNumY = 0;


        // init script
        private static List<Card> GetCards(int numCards)
        {
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
            dict.Add(16, "sixteen");
            dict.Add(17, "seventeen");
            dict.Add(18, "eighteen");
            dict.Add(19, "nineteen");
            dict.Add(20, "twenty");

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

            double Y = cardFieldX / cardFieldY;
            double lower = Math.Ceiling(Math.Sqrt(numCards / Y));

            double upper = Math.Ceiling(numCards / lower);


            int numY = currentNumY = (int)lower;
            int numX = currentNumX = (int)upper;
            
            float c = 0;

            if ((cardFieldY - (numY * cardY + (numY - 1) * cardSpace)) < 0)
            {
                c = -(cardFieldY - numY * cardY - (numY+1)*cardSpace)/(2*numY+1);
            }
            else if ((cardFieldX - (numX * cardX + (numX - 1) * cardSpace)) < 0)
            {
                c = -(cardFieldX - numX * cardX - (numX + 1) * cardSpace) / (2 * numX + 1);
            }


            //foreach (Card card in cards)
            //{
            //    card.Draw(x,y,z);
            //    x += 60 + 30;
            //}

            //int numX = 0;
            //int numY = numCards;

            //int tempNumX = numX;
            ////int tempNumY = numY;


            //while ((tempNumX + 1) <= (numY))
            //{
            //    tempNumX++;
            //    if (numCards % tempNumX == 0)
            //    {
            //        numX = tempNumX;
            //        numY = numCards / tempNumX;
            //    }

            //    if (tempNumX == 3 && numCards % tempNumX != 0)
            //    {
            //        numX = tempNumX;
            //        numY = numCards/tempNumX + 1;
            //        break;
            //    }
            //    else if (tempNumX == 3)
            //    {
            //        break;
            //    }
            //}

            //if (numX < numY)
            //{
            //    tempNumX = numX;
            //    numX = numY;
            //    numY = tempNumX;
            //}

            var computedCardX = cardX-c;
            var computedCardY = cardY-c;
            var computedSpace = cardSpace-c;

            currentCardX = computedCardX;
            currentCardY = computedCardY;
            currentCardSpace = computedSpace;

            float firstPointX = (cardFieldX - (numX * computedCardX + (numX - 1) * computedSpace)) / 2;
            float firstPointY = -(cardFieldY - (numY * computedCardY + (numY - 1) * computedSpace)) / 2;
            float firstPointZ = 0;

            int cardNum = 0;
            for (int i = 0; i < numY; i++)
            {
                for (int j = 0; j < numX; j++)
                {
                    if (cardNum < cards.Count)
                    {
                        cards[cardNum].Draw(firstPointX, firstPointY, firstPointZ, computedCardX, computedCardY);
                        firstPointX += computedCardX + computedSpace;
                        cardNum++;
                    }
                }
                firstPointX = (cardFieldX - (numX * computedCardX + (numX - 1) * computedSpace)) / 2;
                firstPointY -= computedCardY + computedSpace;
            }
            
            return cards;
        }

    }
}
