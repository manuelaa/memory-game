using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Models;

namespace Assets.Scripts.Interfaces
{
    public interface IGameBehaviour
    {
        void Rotate(DegreeEnum degrees);
        void SimpleRotate(int degrees);
        void RotateAndResize(int degrees);
        void QuickRotateReset();
        void SetOriginalSize();
        void DeleteCards();
        void UpdateSizeOfTable();
    }
}
