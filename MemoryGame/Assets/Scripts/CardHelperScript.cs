using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class CardHelperScript : MonoBehaviour
    {

        public void WaitAndRotate(float seconds, string buttonName)
        {
            StartCoroutine(CardRotation(seconds, buttonName));
        }


        public IEnumerator CardRotation(float seconds, string buttonName)
        {
            yield return new WaitForSeconds(seconds);
            //Button btn = (Button)GameObject.Find(buttonName).GetComponent(typeof(Button));
            //btn.image.sprite = Resources.Load<Sprite>("cardBackground");
            Rotate(buttonName, "cardBackground");
        }


        //********************************************* ROTATION ***********************************************************

        private int rotationDirection = -1; // -1 for clockwise, 1 for anti-clockwise
        private int rotationStep = 10;

        private Vector3 currentRotation, targetRotation;

        private GameObject card;

        private string cardName;
        private string imageName;
        private int rotationNum;

        public void Rotate(string _cardName, string _imageName, int _rotationDirection = -1, int _rotationNum = 0)
        {
            Button btn = (Button)GameObject.Find(_cardName).GetComponent(typeof(Button));
            btn.image.sprite = Resources.Load<Sprite>(imageName);

            //rotationNum = _rotationNum;
            //imageName = _imageName;
            //rotationDirection = _rotationDirection;
            //cardName = _cardName;

            //card = GameObject.Find(_cardName);

            //Debug.Log("ROTATION STARTED");

            //currentRotation = card.transform.eulerAngles;

            //targetRotation.x = 0;
            //targetRotation.z = 0;

            //targetRotation.y = (currentRotation.y + (90 * rotationDirection));
            //StartCoroutine(ObjectRotationAnimation());

        }

        IEnumerator ObjectRotationAnimation()
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

                rotationNum++;
                if (rotationNum==1)
                {
                    Button btn = (Button)GameObject.Find(cardName).GetComponent(typeof(Button));
                    btn.image.sprite = Resources.Load<Sprite>(imageName);

                    Rotate(cardName, imageName, rotationDirection*(-1), rotationNum);
                }
                else
                {
                    //Debug.Log("ROTATION ENDED");
                }
            }
        }
    }

}