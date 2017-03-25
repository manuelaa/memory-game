using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Models;

namespace Assets.Scripts.Interfaces
{
    public interface ICardBehaviour
    {
        void Draw(Card card, float x, float y, float z);
        void Rotate();
        void Click();
    }
}
