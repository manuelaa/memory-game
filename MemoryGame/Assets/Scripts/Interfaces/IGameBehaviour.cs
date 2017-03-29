using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Interfaces
{
    public interface IGameBehaviour
    {
        void Rotate(int degrees);
        void RotateAndResize(int degrees);
        void SetOriginalSize();
    }
}
