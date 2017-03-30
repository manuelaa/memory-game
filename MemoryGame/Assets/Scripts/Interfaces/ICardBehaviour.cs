using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Models;
using System.Collections;

namespace Assets.Scripts.Interfaces
{
    public interface ICardBehaviour
    {
        void Draw(Card card, float x, float y, float z, float width, float height);
        void Rotate(bool back, string image);
        void WaitToRotate(float seconds, bool back, string image);
        void Click();
    }
}
