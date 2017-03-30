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
    public class PlayerUnityBehaviour : IPlayerBehaviour
    {
        public void DrawName(PlayerEnum num, string name, int score)
        {
            GameObject.Find(num.ToString());
            Text text = (Text)GameObject.Find(num.ToString()).GetComponent<Text>();

            text.text = name + ", " + score.ToString();

        }

        public void ChangeNameColour(PlayerEnum num, ColorEnum color)
        {
            Text text = (Text)GameObject.Find(num.ToString()).GetComponent<Text>();

            switch (color)
            {
                case ColorEnum.Yellow:
                    text.color = Color.yellow;
                    text.fontStyle = FontStyle.Bold;
                    break;
                default:
                    text.color = Color.white;
                    text.fontStyle = FontStyle.Normal;
                    break;
            }
        }

        public static void HideName(PlayerEnum num)
        {
            GameObject.Find(num.ToString()).SetActive(false);
        }

    }
}
