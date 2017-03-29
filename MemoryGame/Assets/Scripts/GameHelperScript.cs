using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class GameHelperScript : MonoBehaviour
    {

        private int rotationDirection = -1; // -1 for clockwise, 1 for anti-clockwise
        private int rotationStep = 10;

        private Vector3 currentRotation, targetRotation;

        private RectTransform cardField;

        public void Rotate()
        {
            cardField = (RectTransform)GameObject.Find("Cards").GetComponent(typeof(RectTransform));
            //cardField.transform.eulerAngles = new Vector3(0, 0, 90);

            Debug.Log("ROTATION STARTED");

            //GameObject cardField = GameObject.Find("Cards");

            currentRotation = cardField.transform.eulerAngles;
            targetRotation.z = (currentRotation.z + (90 * rotationDirection));
            StartCoroutine(ObjectRotationAnimation());

        }

        IEnumerator ObjectRotationAnimation()
        {
            // add rotation step to current rotation.
            currentRotation.z += (rotationStep * rotationDirection);
            cardField.transform.eulerAngles = currentRotation;
            yield return new WaitForSeconds(0);
            if (((int)currentRotation.z >
            (int)targetRotation.z && rotationDirection < 0) || // for clockwise
            ((int)currentRotation.z < (int)targetRotation.z && rotationDirection > 0)) // for anti-clockwise
            {
                StartCoroutine(ObjectRotationAnimation());
                Debug.Log("CORUTINE STARTED");

            }
            else
            {
                cardField.transform.eulerAngles = targetRotation;
                Debug.Log("ROTATION ENDED");
                cardField = null;

            }
        }




        //*************************


        public void ConsecutivelyWaitAndRotate(float seconds, string buttonName1, string buttonName2)
        {
            StartCoroutine(ConsecutivelyCardRotation(seconds, buttonName1, buttonName2));
        }


        IEnumerator ConsecutivelyCardRotation(float seconds, string buttonName1, string buttonName2)
        {
            GameObject helpGo = GameObject.Find("HelperGameObject");
            var cardHelperScript = (CardHelperScript)helpGo.GetComponent(typeof(CardHelperScript));

            Debug.Log("CONSEQ");

            yield return StartCoroutine(cardHelperScript.CardRotation(seconds, buttonName1));
            //yield return StartCoroutine(cardHelperScript.CardRotation(seconds, buttonName1));
            //yield return StartCoroutine(cardHelperScript.CardRotation(seconds, buttonName2));
        }


        //private int rotationDirection = -1; // -1 for clockwise, 1 for anti-clockwise
        //private int rotationStep = 10;

        //private Vector3 currentRotation, targetRotation;

        private GameObject card;

        private string cardName;
        private string imageName;
        private int rotationNum;




        public void Rotate(string _cardName, string _imageName, int _rotationDirection = -1, int _rotationNum = 0)
        {
            rotationNum = _rotationNum;
            imageName = _imageName;
            rotationDirection = _rotationDirection;
            cardName = _cardName;

            card = GameObject.Find(_cardName);

            Debug.Log("ROTATION STARTED");

            currentRotation = card.transform.eulerAngles;

            targetRotation.x = 0;
            targetRotation.z = 0;

            targetRotation.y = (currentRotation.y + (90 * rotationDirection));


            StartCoroutine(CardObjectRotationAnimation());

        }


        public IEnumerator ConsecutivelyCardRotation3(float seconds, string buttonName1, string buttonName2)
        {
            GameObject helpGo = GameObject.Find("HelperGameObject");
            var cardHelperScript = (CardHelperScript)helpGo.GetComponent(typeof(CardHelperScript));

            Debug.Log("CONSEQ");
            imageName = buttonName1;
            yield return StartCoroutine(CardObjectRotationAnimation());
            Debug.Log("ROTATION1 ENDED");
            imageName = buttonName2;
            yield return StartCoroutine(CardObjectRotationAnimation());
            Debug.LogWarning("ROTATION2 ENDED");
            yield return StartCoroutine(CardObjectRotationAnimation());
            Debug.LogWarning("ROTATION3 ENDED");

        }


        IEnumerator CardObjectRotationAnimation()
        {
            // add rotation step to current rotation.
            //Debug.Log(currentRotation);
            currentRotation.y += (rotationStep * rotationDirection);
            Debug.Log("Current: " + currentRotation);
            Debug.Log("Target: " + targetRotation);

            card.transform.eulerAngles = currentRotation;
            yield return new WaitForSeconds(0);
            if (((int)currentRotation.y >
            (int)targetRotation.y && rotationDirection < 0) || // for clockwise
            ((int)currentRotation.y < (int)targetRotation.y && rotationDirection > 0)) // for anti-clockwise
            {
                StartCoroutine(ObjectRotationAnimation());
                //Debug.Log("CORUTINE STARTED");
            }
            else
            {
                card.transform.eulerAngles = targetRotation;

                //rotationNum++;
                //if (rotationNum == 1)
                //{
                //    Button btn = (Button)GameObject.Find(cardName).GetComponent(typeof(Button));
                //    btn.image.sprite = Resources.Load<Sprite>(imageName);

                //    Rotate(cardName, imageName, rotationDirection * (-1), rotationNum);
                //}
                //else
                //{
                //    //Debug.Log("ROTATION ENDED");
                //}
            }
        }
    }
}
