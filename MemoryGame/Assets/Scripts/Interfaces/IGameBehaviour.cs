using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Interfaces
{
    public interface IGameBehaviour
    {
        void Rotate();
        void RotateConsequently(float seconds, string buttonName1, string buttonName2);
    }
}
