using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Unity
{
    public class GameUnityBehaviour : MonoBehaviour, IGameBehaviour
    {
        public void Rotate()
        {
            GameObject helpGo = GameObject.Find("HelperGameObject");
            var gameHelperScript = (GameHelperScript)helpGo.GetComponent(typeof(GameHelperScript));
            gameHelperScript.Rotate();
        }

        public void RotateConsequently(float seconds, string buttonName1, string buttonName2)
        {
            GameObject helpGo = GameObject.Find("HelperGameObject");
            var gameHelperScript = (GameHelperScript)helpGo.GetComponent(typeof(GameHelperScript));

            gameHelperScript.ConsecutivelyCardRotation3(seconds, buttonName1, buttonName2);

        }

        
    }
}
