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
    /// <summary>
    /// Class for Unity specific behaviour of player
    /// </summary>
    public class PlayerUnityBehaviour : IPlayerBehaviour
    {
        /// <summary>
        /// Draws name of defined player
        /// </summary>
        /// <param name="num">Draws name for these player</param>
        /// <param name="name">...with these name</param>
        /// <param name="score">... and with these score</param>
        public void DrawName(PlayerEnum num, string name, int score)
        {
            GameObject.Find(num.ToString());
            Text text = (Text)GameObject.Find(num.ToString()).GetComponent<Text>();

            text.text = name + ", " + score.ToString();

        }

        /// <summary>
        /// Changes players <param name="num"></param> text color to <param name="color"></para>
        /// </summary>
        /// <param name="num"></param>
        /// <param name="color"></param>
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

        /// <summary>
        /// When needed hides playere names. When number of players is not max possible number.
        /// </summary>
        /// <param name="num"></param>
        public static void HideName(PlayerEnum num)
        {
            GameObject.Find(num.ToString()).SetActive(false);
        }

    }
}
