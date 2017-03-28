using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Interfaces
{
    public interface ICard
    {
        void Draw(float x, float y, float z);
        void Rotate(bool back);
        void WaitToRotate(float seconds, bool back);
        void Click();
    }
    
}
