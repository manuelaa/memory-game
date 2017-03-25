using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Interfaces;

namespace Assets.Scripts.Models
{
    class Card
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public ICardBehaviour Behavior { get; set; }

        public Card(int _ID, string _code, string _name, ICardBehaviour _behavior)
        {
            ID = _ID;
            Code = _code;
            Name = _name;
            Behavior = _behavior;
        }

        public void Play()
        {
            Behavior.Play();
        }
    }
}
