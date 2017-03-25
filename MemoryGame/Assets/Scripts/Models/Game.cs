using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Factories;
using Assets.Scripts.Interfaces;
using Assets.Scripts.Unity;

namespace Assets.Scripts.Models
{
    class Game
    {
        List<Card> CardList;
        List<Player> PlayerList;

        public Game(ICardBehaviour cardBehaviour, IPlayerBehaviour playerBehaviour, int numPlayers)
        {
            CardList = CardFactory.GetCards(cardBehaviour);
            PlayerList = PlayerFactory.GetPlayers(numPlayers, playerBehaviour);
        }

    }
}
