﻿using System;
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
    public class CardUnityBehaviour : MonoBehaviour, ICardBehaviour, IPointerClickHandler
    {
        //private Card Card;
        private MainScript mainScript;
        
        void Start()
        {
            GameObject go = GameObject.Find("Camera");
            mainScript = (MainScript)go.GetComponent(typeof(MainScript));
        }

        public void Click()
        {
            throw new NotImplementedException();
        }
        
        public void Draw(Card _card, float x, float y, float z)
        {
            GameObject gameObject = GameObject.Find("Cards");
            Button buttonPrefab = (Button)GameObject.Find("CardPrefab").GetComponent(typeof(Button));

            Button btn = Instantiate(buttonPrefab);
            btn.transform.position = new Vector3(x, y, z);
            btn.name = _card.ID.ToString();
            //btn.onClick.AddListener(() => OnClick());
            btn.transform.SetParent(gameObject.transform, false);

            //btn.GetComponent<Button>().onClick.AddListener((delegate { OnClick(); }));
            btn.GetComponent<Button>().onClick.AddListener(() => OnClick());
            
            //Card = _card;
        }

        public void OnClick()
        {
            //Debug.Log("CLICKED" + Card.Name);
            //main. ...

        }

        public void OnPointerClick(PointerEventData eventData)
        {
            //Debug.Log("HERE");
            mainScript.CardChanges(Convert.ToInt32(EventSystem.current.currentSelectedGameObject.name));
            //Debug.Log(EventSystem.current.currentSelectedGameObject.name);
        }

        public void Rotate()
        {
            throw new NotImplementedException();
        }
    }
}
