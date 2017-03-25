using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Interfaces;
using Assets.Scripts.Models;

namespace Assets.Scripts.Factories
{
    public class PlayerFactory
    {
        public static List<Player> GetPlayers(int num, IPlayerBehaviour _behaviour)
        {
            List<Player> Players = new List<Player>();
            Players.Add(new Player(1, "Player1", _behaviour, PlayerEnum.Player1));
            Players.Add(new Player(2, "Player2", _behaviour, PlayerEnum.Player2));
            Players.Add(new Player(3, "Player3", _behaviour, PlayerEnum.Player3));
            Players.Add(new Player(4, "Player4", _behaviour, PlayerEnum.Player4));
            return Players;
        }
    }
}
