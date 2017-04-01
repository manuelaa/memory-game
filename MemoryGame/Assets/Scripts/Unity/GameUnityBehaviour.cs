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
    /// <summary>
    /// Class for Unity specific behaviour of Game
    /// </summary>
    public class GameUnityBehaviour : MonoBehaviour, IGameBehaviour
    {
        /// <summary>
        /// Rotates gametable
        /// </summary>
        /// <param name="degrees"></param>
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

        /// <summary>
        /// Resets stored numbers
        /// </summary>
        public void QuickRotateReset()
        {
            var cardField = (RectTransform)GameObject.Find("Cards").GetComponent(typeof(RectTransform));
            cardField.transform.eulerAngles = new Vector3(0, 0, 0);
        }

        /// <summary>
        /// Rotates gametable
        /// </summary>
        /// <param name="degrees"></param>
        public void SimpleRotate(int degrees)
        {
            GameHelperScript gameHelperScript = (GameHelperScript)GameObject.Find("HelperGameObject").GetComponent(typeof(GameHelperScript));
            gameHelperScript.Rotate(degrees);
        }

        /// <summary>
        /// Rotates and resizes gametable
        /// </summary>
        /// <param name="degrees"></param>
        public void RotateAndResize(int degrees)
        {
            GameHelperScript gameHelperScript = (GameHelperScript)GameObject.Find("HelperGameObject").GetComponent(typeof(GameHelperScript));
            gameHelperScript.ResizeAndRotate(degrees);
        }

        /// <summary>
        /// Sets original sizes
        /// </summary>
        public void SetOriginalSize()
        {
            GameHelperScript gameHelperScript = (GameHelperScript)GameObject.Find("HelperGameObject").GetComponent(typeof(GameHelperScript));
            gameHelperScript.SetOriginalSize();
        }
        
        /// <summary>
        /// Sets original sizes
        /// </summary>
        public void ReturnOriginalSize()
        {
            GameHelperScript gameHelperScript = (GameHelperScript)GameObject.Find("HelperGameObject").GetComponent(typeof(GameHelperScript));
            gameHelperScript.ReturnOriginalSize();
        }

        /// <summary>
        /// Destroys cards
        /// </summary>
        public void DeleteCards()
        {
            var cards = GameObject.Find("Cards");//getch(typeof (Button));

            foreach (Transform child in cards.transform)
                Destroy(child.gameObject);
        }

        /// <summary>
        /// Updates size of table to defined values
        /// </summary>
        /// <param name="numX"></param>
        /// <param name="numY"></param>
        /// <param name="cardX"></param>
        /// <param name="cardY"></param>
        /// <param name="cardSpace"></param>
        public void UpdateSizeOfTable(int numX, int numY, float cardX, float cardY, float cardSpace)
        {
            GameObject go = GameObject.Find("Cards");
            RectTransform cardField = (RectTransform)go.GetComponent(typeof(RectTransform));
            var originalSize = cardField.rect;

            var newWidth = numX*cardX + (numX - 1)*cardSpace;

            if (cardField.rect.width > newWidth)
            {
                var allChildren = go.transform.Cast<Transform>().Select(t => t.gameObject).ToArray();
                go.transform.DetachChildren();

                cardField.localScale = new Vector3(newWidth / originalSize.width, 1, 1);

                foreach (GameObject child in allChildren)
                {
                    child.transform.parent = go.transform;
                }

            }

            
        }

        
    }
}
