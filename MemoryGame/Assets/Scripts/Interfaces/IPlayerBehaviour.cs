using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Models;

namespace Assets.Scripts.Interfaces
{
    public interface IPlayerBehaviour
    {
        void DrawName(PlayerEnum num, string name, int score);
    }
}
