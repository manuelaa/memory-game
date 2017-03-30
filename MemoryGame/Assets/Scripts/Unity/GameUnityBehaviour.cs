using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Interfaces;
using Assets.Scripts.Models;
using UnityEngine;
using UnityEngine.UI;

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

        public void QuickRotateReset()
        {
            var cardField = (RectTransform)GameObject.Find("Cards").GetComponent(typeof(RectTransform));
            cardField.transform.eulerAngles = new Vector3(0, 0, 0);
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

        public void DeleteCards()
        {
            var cards = GameObject.Find("Cards");//getch(typeof (Button));

            foreach (Transform child in cards.transform)
                Destroy(child.gameObject);
        }

        public void UpdateSizeOfTable()
        {
            GameObject go = GameObject.Find("Cards");
            RectTransform cardField = (RectTransform)go.GetComponent(typeof(RectTransform));
            var originalSize = cardField.rect;

            RectTransform card = (RectTransform)go.GetComponent(typeof(RectTransform));
            var originalCardSize = cardField.rect;
            
            //cardField.transform.localScale = new Vector3(width / originalSize.width, 1);
        }
    }
}
