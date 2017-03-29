using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Interfaces;
using Assets.Scripts.Models;
using UnityEngine;

namespace Assets.Scripts.Unity
{
    public class GameUnityBehaviour : MonoBehaviour, IGameBehaviour
    {

        public void Rotate(DegreeEnum degrees)
        {
            switch (degrees)
            {
                case DegreeEnum.DegreesPlus90:
                    RotateAndResize(Convert.ToInt32(degrees));
                    break;
                case DegreeEnum.DegreesMinus90:
                    RotateAndResize(Convert.ToInt32(degrees));
                    break;
                case DegreeEnum.DegreesPlus270:
                    RotateAndResize(Convert.ToInt32(degrees));
                    break;
                case DegreeEnum.DegreesPlus180:
                    SimpleRotate(Convert.ToInt32(degrees));
                    break;
                //case DegreeEnum.Degrees180:
                default:
                    SimpleRotate(Convert.ToInt32(degrees));
                    break;

            }
        }


        public void SimpleRotate(int degrees)
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
