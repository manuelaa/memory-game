using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Interfaces;
using Assets.Scripts.Models;
using Assets.Scripts.Unity;

namespace Assets.Scripts.Factories
{
    public class PlayerFactory
    {
        public static List<Player> GetPlayers(int num, IPlayerBehaviour _behaviour)
        {
            List<Player> Players = new List<Player>();

            for (int i = 1; i <= num; i++)
            {
                Players.Add(new Player(i, "Player"+i.ToString(), _behaviour, (PlayerEnum)i));
            }

            for (int i = num+1; i <= 4; i++)
            {
                PlayerUnityBehaviour.HideName((PlayerEnum)i);
            }

            return Players;
        }
    }
}
