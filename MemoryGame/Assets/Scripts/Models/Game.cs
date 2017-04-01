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
    /// <summary>
    /// Game logic is based here
    /// </summary>
    public class Game
    {
        // all cards used for game
        List<Card> CardList;
        // all players in game
        List<Player> PlayerList;

        // stores degrees for each transition
        Dictionary<string, DegreeEnum> degrees = new Dictionary<string, DegreeEnum>();

        private int _currentPlayer = 0; // index
        private int _currentDegree = 0;

        private int _numCards = 0;

        // counts card clicked
        private int _cardCounter = 0;

        // defines if table rotation is allowed in game
        private bool _rotationAllowed = true;

        private float _cardFieldWidth = 0;
        private float _cardFieldHeight = 0;

        private IGameBehaviour GameBehaviour;

        private Card card1; // first clicked card

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

        /// <summary>
        /// Initializes degree dictionary (dictionary used for card transitions with appropriate degrees between them)
        /// </summary>
        public void InitDegrees()
        {
            degrees.Add("1_2", DegreeEnum.DegreesPlus180);
            degrees.Add("2_1", DegreeEnum.DegreesPlus180);
            degrees.Add("2_3", DegreeEnum.DegreesPlus90);
            degrees.Add("3_1", DegreeEnum.DegreesPlus90);
            degrees.Add("3_4", DegreeEnum.DegreesPlus180);
            degrees.Add("4_1", DegreeEnum.DegreesPlus270);

        }

        /// <summary>
        /// Handles card changes, in other words, function started afrer card is clicked
        /// </summary>
        /// <param name="cardId">Id of clicked card</param>
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
                    //UnityEngine.Debug.Log("ISTA KARTA");
                    // card1 se ne nullira jer nije ispravan drugi klik
                    return; // klikanje iste karte
                }
                else if (card1.Code == card2.Code)
                {
                    //POGODAK
                    card2.Rotate(false);

                    //UnityEngine.Debug.Log("POGODAK");

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

                    //UnityEngine.Debug.Log("wrooooooooong");
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
                //UnityEngine.Debug.Log("PRVO KLIKANJE");
            }
        }

        /// <summary>
        /// Handles player changesclicked
        /// </summary>
        /// <param name="scored"></param>
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

        /// <summary>
        /// Changes colour of writen name and score for current player
        /// </summary>
        /// <param name="color"></param>
        public void ChangeColourCurrentPlayer(ColorEnum color)
        {
            var current = PlayerList[_currentPlayer];
            current.Behaviour.ChangeNameColour(current.PlayerNum, color);
        }

        /// <summary>
        /// Updates players score
        /// </summary>
        /// <param name="scored"></param>
        public void RewritePlayerScore(bool scored)
        {
            if (scored)
                PlayerList[_currentPlayer].Score++;
            PlayerList[_currentPlayer].Draw();
        }

        /// <summary>
        /// When rotation and resize is needed
        /// </summary>
        public void RotateAndResize()
        {
            GameBehaviour.RotateAndResize(90);
        }

        /// <summary>
        /// when only rotation is needed
        /// </summary>
        public void Rotate()
        {
            GameBehaviour.Rotate(DegreeEnum.DegreesPlus180);
        }

        /// <summary>
        /// Checks if game is over. Game is over when all cards are found.
        /// </summary>
        /// <returns></returns>
        public bool CheckEnd()
        {
            //UnityEngine.Debug.Log(_cardCounter);

            return _cardCounter == _numCards;
        }

        /// <summary>
        /// Find who is winner. If two or more players have same score, there is no winner.
        /// </summary>
        /// <returns></returns>
        public string GetWinner()
        {

            var theBest = PlayerList.OrderByDescending(p => p.Score).First();
            if (PlayerList.Any(x => x.Score == theBest.Score && x.ID != theBest.ID))
                return "No one";
            return theBest.Name;
        }

        /// <summary>
        /// When game is played again, all fileds are reseted
        /// </summary>
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

            GameBehaviour.UpdateSizeOfTable(CardFactory.currentNumX, CardFactory.currentNumY, CardFactory.currentCardX, CardFactory.currentCardY, CardFactory.currentCardSpace);
            

            GameBehaviour.SetOriginalSize();

        }

    }
}
