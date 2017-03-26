using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Assets.Scripts.Factories;
using Assets.Scripts.Interfaces;
using Assets.Scripts.Unity;

namespace Assets.Scripts.Models
{
    public class Game
    {
        List<Card> CardList;
        List<Player> PlayerList;

        private Card card1;

        public Game(ICardBehaviour cardBehaviour, IPlayerBehaviour playerBehaviour, int numPlayers)
        {
            PlayerList = PlayerFactory.GetPlayers(numPlayers, playerBehaviour);
            CardList = CardFactory.DrawCards();
        }

        public void CardChanges(int cardId)
        {
            if (card1 != null)
            {
                //drugo klikanje
                var card2 = CardList.First(x => x.ID == cardId);
                if (card1.ID == card2.ID)
                {
                    UnityEngine.Debug.Log("ISTA KARTA DUDE");
                    // card1 se ne nullira jer nije ispravan drugi klik
                    return; // klikanje iste karte
                }
                else if (card1.Code == card2.Code)
                {
                    //POGODAK
                    UnityEngine.Debug.Log("POGODAK");
                    card1 = null;
                    // klikanje druge karte
                }
                else
                {
                    UnityEngine.Debug.Log("wrooooooooong");
                    card1 = null;
                }
            }
            else
            {
                //prvo klikanje
                card1 = CardList.First(x => x.ID == cardId);
                UnityEngine.Debug.Log("PRVO KLIKANJE");
            }
        }

        public void PlayerChanges()
        {

        }

    }
}
