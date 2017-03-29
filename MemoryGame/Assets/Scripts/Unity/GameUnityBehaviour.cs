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

        public void Rotate(int degrees)
        {
            GameHelperScript gameHelperScript = (GameHelperScript)GameObject.Find("HelperGameObject").GetComponent(typeof(GameHelperScript));
            gameHelperScript.Rotate(degrees);
        }

        public void RotateAndResize(int degrees)
        {
            GameHelperScript gameHelperScript = (GameHelperScript)GameObject.Find("HelperGameObject").GetComponent(typeof(GameHelperScript));
            gameHelperScript.ResizeAndRotate(degrees);

        }

        public void SetOriginalSize()
        {
            GameHelperScript gameHelperScript = (GameHelperScript)GameObject.Find("HelperGameObject").GetComponent(typeof(GameHelperScript));
            gameHelperScript.SetOriginalSize();
        }
    }
}
