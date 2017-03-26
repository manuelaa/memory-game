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
            //Cards.Add(new Card(5, "THREE", " Three", behaviour));
            //Cards.Add(new Card(6, "THREE", " Three", behaviour));
            //Cards.Add(new Card(7, "FOUR", " Four", behaviour));
            //Cards.Add(new Card(8, "FOUR", " Four", behaviour));


            return Cards;
        }

        public static List<Card> DrawCards()
        {
            List<Card> cards = GetCards();
            int x = 0;
            int y = 0;
            int z = 0;

            foreach (Card card in cards)
            {
                card.Draw(x,y,z);
                x += 60 + 30;
            }
            return cards;
        }
    }
}
