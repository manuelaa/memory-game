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

        Dictionary<string, DegreeEnum> degrees = new Dictionary<string, DegreeEnum>();

        private int _currentPlayer = 0;
        private int _currentDegree = 0;

        private int _numCards = 0;
        private int _cardCounter = 0;

        private bool _rotationAllowed = true;

        private float _cardFieldWidth = 0;
        private float _cardFieldHeight = 0;

        private IGameBehaviour GameBehaviour;

        private Card card1;

        public Game(IGameBehaviour gameBehaviour, ICardBehaviour cardBehaviour, IPlayerBehaviour playerBehaviour, int numPlayers, int numCards, bool rotationAllowed, float cardFieldWidth, float cardFieldHeight)
        {
            GameBehaviour = gameBehaviour;
            PlayerList = PlayerFactory.GetPlayers(numPlayers, playerBehaviour);
            ChangeColourCurrentPlayer(ColorEnum.Yellow);
            
            InitDegrees();
            _numCards = numCards * 2;
            CardList = CardFactory.DrawCards(_numCards, cardFieldWidth, cardFieldHeight);

            GameBehaviour.UpdateSizeOfTable(CardFactory.currentNumX, CardFactory.currentNumY, CardFactory.currentCardX, CardFactory.currentCardY, CardFactory.currentCardSpace);

            _cardFieldWidth = cardFieldWidth;
            _cardFieldHeight = cardFieldHeight;
            _currentDegree = 0;

            _rotationAllowed = rotationAllowed;

            GameBehaviour.SetOriginalSize();



        }

        public void InitDegrees()
        {
            degrees.Add("1_2", DegreeEnum.DegreesPlus180);
            degrees.Add("2_1", DegreeEnum.DegreesPlus180);
            degrees.Add("2_3", DegreeEnum.DegreesPlus90);
            degrees.Add("3_1", DegreeEnum.DegreesPlus90);
            degrees.Add("3_4", DegreeEnum.DegreesPlus180);
            degrees.Add("4_1", DegreeEnum.DegreesPlus270);

        }

        public void CardChanges(int cardId)
        {
            var card = CardList.First(x => x.ID == cardId);
            if (card.correct)
                return; //ignore click

            if (card1 != null)
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
                    card2.Rotate(false);

                    UnityEngine.Debug.Log("wrooooooooong");
                    UnityEngine.Debug.Log(card1.Code);
                    UnityEngine.Debug.Log(card2.Code);

                    card1.WaitToRotate(1f, true);
                    card2.WaitToRotate(1f, true);
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
            int oldPlayer = _currentPlayer;
            // ako nije pogodio onda se igrac mijenja, i azuriraju se bodovi
            if (!scored)
            {
                ChangeColourCurrentPlayer(ColorEnum.White);

                _currentPlayer++;
                if (_currentPlayer == PlayerList.Count)
                    _currentPlayer = 0;

                ChangeColourCurrentPlayer(ColorEnum.Yellow);

                if (_rotationAllowed)
                {
                    var key = (oldPlayer + 1).ToString() + '_' + (_currentPlayer + 1).ToString();
                    var degree = degrees[key];
                    GameBehaviour.Rotate(degree);
                }
            }
        }

        public void ChangeColourCurrentPlayer(ColorEnum color)
        {
            var current = PlayerList[_currentPlayer];
            current.Behaviour.ChangeNameColour(current.PlayerNum, color);
        }

        public void RewritePlayerScore(bool scored)
        {
            if (scored)
                PlayerList[_currentPlayer].Score++;
            PlayerList[_currentPlayer].Draw();
        }

        public void RotateAndResize()
        {
            GameBehaviour.RotateAndResize(90);
        }

        public void Rotate()
        {
            GameBehaviour.Rotate(DegreeEnum.DegreesPlus180);
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
            GameBehaviour.DeleteCards();
            GameBehaviour.QuickRotateReset();
            GameBehaviour.ReturnOriginalSize();
            CardList = CardFactory.DrawCards(_numCards, _cardFieldWidth, _cardFieldHeight);
            
            foreach (Player player in PlayerList)
            {
                player.Score = 0;
                player.Draw();
            }

            _cardCounter = 0;
            _currentPlayer = 0;
        }

    }
}
