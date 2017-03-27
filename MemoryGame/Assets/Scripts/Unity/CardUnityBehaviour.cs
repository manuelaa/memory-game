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

            btn.image.sprite = Resources.Load<Sprite>("cardBackground");

            btn.transform.SetParent(gameObject.transform, false);

            //btn.GetComponent<Button>().onClick.AddListener((delegate { OnClick(); }));
            btn.GetComponent<Button>().onClick.AddListener(() => OnClick());
            buttonName = _card.ID.ToString();
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
            Debug.Log(EventSystem.current.currentSelectedGameObject.name);
        }

        public void Rotate(bool back=true, string image= "cardBackground")
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

        private void RotateAfterDelay()
        {
            Rotate();
        }

        public void WaitToRotate(float seconds, bool back)
        {
            //Invoke("RotateAfterDelay", seconds);

            //TODO: change!
            //DateTime now = DateTime.Now;
            //DateTime then = now.AddSeconds(1);
            //while (then>now)
            //{
            //    now = DateTime.Now;
            //}
            Rotate(true);
            
            //Wait(5, () => {
            //    Rotate(back);
            //    Debug.Log("ASDASD");
            //});
        }

        //private void Wait(float seconds, Action action)
        //{
        //    StartCoroutine(_wait(seconds, action));
        //}

        //private IEnumerator _wait(float time, Action callback)
        //{
        //    yield return new WaitForSeconds(time);
        //    callback();
        //}
    }
}
