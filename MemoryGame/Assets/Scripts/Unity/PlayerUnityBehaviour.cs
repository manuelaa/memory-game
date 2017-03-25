using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Interfaces;
using Assets.Scripts.Models;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Unity
{
    class PlayerUnityBehaviour : IPlayerBehaviour
    {
        public void DrawName(PlayerEnum num, string name)
        {
            Text text = (Text)GameObject.Find(num.ToString()).GetComponent<Text>();
            text.text = name;
            
        }
    }
}
