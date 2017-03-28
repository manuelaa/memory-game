using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Interfaces;

namespace Assets.Scripts.Models
{
    public class Card : ICard
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public ICardBehaviour Behavior { get; set; }
        public bool correct { get; set; }

        public Card(int _ID, string _code, string _name, ICardBehaviour _behavior)
        {
            ID = _ID;
            Code = _code;
            Name = _name;
            Behavior = _behavior;
            correct = false;
        }

        public void Draw(float x, float y, float z)
        {
            Behavior.Draw(this, x, y, z);
        }

        public void Rotate(bool back)
        {
            Behavior.Rotate(back, Code.ToLower());
        }

        public void WaitToRotate(float seconds, bool back)
        {
            Behavior.WaitToRotate(seconds, back, Code.ToLower());
        }

        public void Click()
        {
            //Behavior.Draw();
        }


    }
}
