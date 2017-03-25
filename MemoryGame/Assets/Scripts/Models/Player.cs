﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Interfaces;

namespace Assets.Scripts.Models
{
    class Player : IPlayer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
        public IPlayerBehaviour Behaviour { get; set; }
        public PlayerEnum PlayerNum { get; set; }


        public Player(int ID, string name, IPlayerBehaviour behaviour, PlayerEnum player)
        {
            ID = ID;
            Name = name;
            Score = 0;
            Behaviour = behaviour;
            PlayerNum = player;
            Draw();
        }

        public void Draw()
        {
            Behaviour.DrawName(PlayerNum, Name);
        }
    }
}