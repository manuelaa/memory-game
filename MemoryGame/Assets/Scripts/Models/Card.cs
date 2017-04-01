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

        /// <summary>
        /// Draws a card on defineed coordinates with defined size
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void Draw(float x, float y, float z, float width, float height)
        {
            Behavior.Draw(this, x, y, z, width, height);
        }

        /// <summary>
        /// Rotates card
        /// </summary>
        /// <param name="back">If back is true then card should be on reverse side, othervise, image should be visible</param>
        public void Rotate(bool back)
        {
            Behavior.Rotate(back, Code.ToLower());
        }

        /// <summary>
        /// Waits defined number of seconds and then rotates
        /// </summary>
        /// <param name="seconds">Number of seconds to waite before card rotation</param>
        /// <param name="back">If back is true then card should be on reverse side, othervise, image should be visible</param>
        public void WaitToRotate(float seconds, bool back)
        {
            Behavior.WaitToRotate(seconds, back, Code.ToLower());
        }
        

    }
}
