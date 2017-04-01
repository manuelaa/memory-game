using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Interfaces;
using Assets.Scripts.Models;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts.Unity
{
    /// <summary>
    /// Class for Unity specific behaviour of card
    /// </summary>
    public class CardUnityBehaviour : MonoBehaviour, ICardBehaviour, IPointerClickHandler
    {
        //private Card Card;
        private MainScript mainScript;
        private string buttonName = "";

        void Start()
        {
            GameObject go = GameObject.Find("Camera");
            mainScript = (MainScript)go.GetComponent(typeof(MainScript));
        }
        
        /// <summary>
        /// Draws card on defined position with defined size
        /// </summary>
        /// <param name="_card"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void Draw(Card _card, float x, float y, float z, float width, float height)
        {
            GameObject gameObject = GameObject.Find("Cards");
            Button buttonPrefab = (Button)GameObject.Find("CardPrefab").GetComponent(typeof(Button));
            RectTransform cardField = (RectTransform)GameObject.Find("CardPrefab").GetComponent(typeof(RectTransform));
            var originalSize = cardField.rect;
            cardField.transform.localScale = new Vector3(width / originalSize.width, height / originalSize.height);
            
            Button btn = Instantiate(buttonPrefab);
            btn.transform.position = new Vector3(x, y, z);


            btn.name = _card.ID.ToString();
            //btn.onClick.AddListener(() => OnClick());

            btn.image.sprite = Resources.Load<Sprite>("cardBackground");

            btn.transform.SetParent(gameObject.transform, false);
            buttonName = _card.ID.ToString();
        }

        /// <summary>
        /// Starts when click event is triggered
        /// </summary>
        /// <param name="eventData"></param>
        public void OnPointerClick(PointerEventData eventData)
        {
            mainScript.CardChanges(Convert.ToInt32(EventSystem.current.currentSelectedGameObject.name));
        }


        /// <summary>
        /// Rotates a card on either image side or back side
        /// </summary>
        /// <param name="back"></param>
        /// <param name="image"></param>
        public void Rotate(bool back = true, string image = "cardBackground")
        {

            Button btn = (Button)GameObject.Find(buttonName).GetComponent(typeof(Button));
            if (!back)
            {
                btn.image.sprite = Resources.Load<Sprite>("CardImages/" + image);
            }
            else
            {
                btn.image.sprite = Resources.Load<Sprite>("cardBackground");
            }
        }

        /// <summary>
        /// Rotates card but after defined number of seconds
        /// </summary>
        /// <param name="seconds"></param>
        /// <param name="back"></param>
        /// <param name="image"></param>
        public void WaitToRotate(float seconds, bool back, string image)
        {
            Rotate(false, image);
            GameObject helpGo = GameObject.Find("HelperGameObject");
            var cardHelperScript = (CardHelperScript)helpGo.GetComponent(typeof(CardHelperScript));
            cardHelperScript.WaitAndRotate(seconds, buttonName);
        }
    }
}
