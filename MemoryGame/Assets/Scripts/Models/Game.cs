﻿using System;
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

        private int currentPlayer = 0;

        private int _numCards = 0;
        private int _cardCounter = 0;

        private float _cardFieldWidth = 0;
        private float _cardFieldHeight = 0;

        private IGameBehaviour GameBehaviour;

        private Card card1;

        public Game(IGameBehaviour gameBehaviour, ICardBehaviour cardBehaviour, IPlayerBehaviour playerBehaviour, int numPlayers, int numCards, float cardFieldWidth, float cardFieldHeight)
        {
            GameBehaviour = gameBehaviour;
            PlayerList = PlayerFactory.GetPlayers(numPlayers, playerBehaviour);
            _numCards = numCards * 2;
            CardList = CardFactory.DrawCards(_numCards, cardFieldWidth, cardFieldHeight);
            _cardFieldWidth = cardFieldWidth;
            _cardFieldHeight = cardFieldHeight;

        }

        public void CardChanges(int cardId)
        {
            var card = CardList.First(x => x.ID == cardId);
            if(card.correct)
                return; //ignore click

            if (card1 != null )
            {
                //drugo klikanje
                var card2 = card;
                if (card1.ID == card2.ID)
                {
                    UnityEngine.Debug.Log("ISTA KARTA DUDE");
                    // card1 se ne nullira jer nije ispravan drugi klik
                    return; // klikanje iste karte
                }
                else if (card1.Code == card2.Code)
                {
                    //POGODAK
                    card2.Rotate(false);

                    UnityEngine.Debug.Log("POGODAK");

                    CardList[CardList.IndexOf(card1)].correct = true;
                    CardList[CardList.IndexOf(card2)].correct = true;
                    card1 = null;

                    _cardCounter += 2;
                    PlayerChanges(true);
                    // klikanje druge karte
                }
                else
                {
                    //card2.Rotate(false);

                    UnityEngine.Debug.Log("wrooooooooong");
                    //UnityEngine.Debug.Log(card1.Code);
                    //UnityEngine.Debug.Log(card2.Code);
                     
                    GameBehaviour.RotateConsequently(0.5f,card2.Behavior.GetButtonName(), card1.Behavior.GetButtonName());

                    //card1.WaitToRotate(2f, true);
                    //card2.WaitToRotate(2f, true);
                    PlayerChanges(false);
                    card1 = null;
                }
            }
            else
            {
                //prvo klikanje
                card1 = card;
                card1.Rotate(false);
                UnityEngine.Debug.Log("PRVO KLIKANJE");
            }
        }

        public void PlayerChanges(bool scored)
        {
            RewritePlayerScore(scored);

            // ako nije pogodio onda se igrac ne mijenja, ali se svejedno azuriraju  bodovi
            if (!scored)
            {
                currentPlayer++;
                if (currentPlayer == PlayerList.Count)
                    currentPlayer = 0;
            }
        }

        public void RewritePlayerScore(bool scored)
        {
            if (scored)
                PlayerList[currentPlayer].Score++;
            PlayerList[currentPlayer].Draw();
        }

        public void Rotate()
        {
            GameBehaviour.Rotate();
        }

        public bool CheckEnd()
        {
            //UnityEngine.Debug.Log(_cardCounter);

            return _cardCounter == _numCards;
        }

        public string GetWinner()
        {

            var theBest = PlayerList.OrderByDescending(p => p.Score).First();
            if (PlayerList.Any(x => x.Score == theBest.Score && x.ID != theBest.ID))
                return "No one";
            return theBest.Name;
        }

        public void Reset()
        {
            foreach (Card card in CardList)
            {
                card.correct = false;
                card.Rotate(true);
            }

            foreach (Player player in PlayerList)
            {
                player.Score = 0;
                player.Draw();
            }

            _cardCounter = 0;
            currentPlayer = 0;
        }

    }
}
