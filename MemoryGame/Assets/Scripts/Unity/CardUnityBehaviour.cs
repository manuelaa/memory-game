using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Interfaces;
using Assets.Scripts.Models;
using UnityEngine;

namespace Assets.Scripts.Unity
{
    public class CardUnityBehaviour : ICardBehaviour
    {
        private Card card;
        private CardsScript cardsScript;

        public CardUnityBehaviour()
        {
            GameObject go = GameObject.Find("Cards");
            cardsScript = (CardsScript)go.GetComponent(typeof(CardsScript));
        }

        public void Click()
        {
            throw new NotImplementedException();
        }

        public void Draw(Card card, float x, float y, float z)
        {
            cardsScript.DrawCard(card, x, y, z);
        }

        public void Rotate()
        {
            throw new NotImplementedException();
        }
    }
}
