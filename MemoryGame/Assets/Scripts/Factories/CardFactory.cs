using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Interfaces;
using Assets.Scripts.Models;
using Assets.Scripts.Unity;

namespace Assets.Scripts.Factories
{
    class CardFactory
    {
        public static List<Card> GetCards(ICardBehaviour Behaviour)
        {
            //TODO: do it right

            List<Card> Cards = new List<Card>();
            Cards.Add(new Card(1, "ONE", "One", Behaviour));
            Cards.Add(new Card(2, "ONE", "One", Behaviour));
            Cards.Add(new Card(3, "TWO", " Two", Behaviour));
            Cards.Add(new Card(4, "TWO", " Two", Behaviour));
            Cards.Add(new Card(5, "THREE", " Three", Behaviour));
            Cards.Add(new Card(6, "THREE", " Three", Behaviour));
            Cards.Add(new Card(7, "FOUR", " Four", Behaviour));
            Cards.Add(new Card(8, "FOUR", " Four", Behaviour));


            return new List<Card>();
        }
    }
}
