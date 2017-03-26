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
        private static List<Card> GetCards()
        {
            //TODO: do it right

            List<Card> Cards = new List<Card>();
            Cards.Add(new Card(1, "ONE", "One", new CardUnityBehaviour()));
            Cards.Add(new Card(2, "ONE", "One", new CardUnityBehaviour()));
            Cards.Add(new Card(3, "TWO", " Two", new CardUnityBehaviour()));
            Cards.Add(new Card(4, "TWO", " Two", new CardUnityBehaviour()));
            Cards.Add(new Card(5, "THREE", "Three", new CardUnityBehaviour()));
            Cards.Add(new Card(6, "THREE", "Three", new CardUnityBehaviour()));
            Cards.Add(new Card(7, "FOUR", "Four", new CardUnityBehaviour()));
            Cards.Add(new Card(8, "FOUR", "Four", new CardUnityBehaviour()));
            Cards.Add(new Card(9, "FIVE", "Five", new CardUnityBehaviour()));
            Cards.Add(new Card(10, "FIVE", "Five", new CardUnityBehaviour()));
            Cards.Add(new Card(11, "SIX", " Six", new CardUnityBehaviour()));
            Cards.Add(new Card(12, "SIX", " Six", new CardUnityBehaviour()));
            return Cards;
        }

        public static List<Card> DrawCards()
        {
            List<Card> cards = GetCards();
            cards.Shuffle();

            int x = 120;
            int y = 0;
            int z = 0;

            //foreach (Card card in cards)
            //{
            //    card.Draw(x,y,z);
            //    x += 60 + 30;
            //}

            int cardNum = 0;
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    cards[cardNum].Draw(x, y, z);
                    x += 60 + 40;
                    cardNum++;
                }
                x = 120;
                y = -83 - 40;
            }

            return cards;
        }
    }
}
