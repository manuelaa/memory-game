using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Assets.Scripts
{
    /// <summary>
    /// Script attached to HelperGameObject in MainScene.
    /// Script has to be attached because using corutines would not be possible if in the scene does not exists object with these script.
    /// </summary>
    public class CardHelperScript : MonoBehaviour
    {

        public void WaitAndRotate(float seconds, string buttonName)
        {
            StartCoroutine(CardRotation(seconds, buttonName));
        }

        IEnumerator CardRotation(float seconds, string buttonName)
        {
            yield return new WaitForSeconds(seconds);
            Button btn = (Button)GameObject.Find(buttonName).GetComponent(typeof(Button));
            btn.image.sprite = Resources.Load<Sprite>("cardBackground");

            //RotateToImage(buttonName);
        }

        /// <summary>
        /// These functions are not used because of problems with corutines.
        /// </summary>
        #region Rotation
        private int rotationDirection; // -1 for clockwise, 1 for anti-clockwise
        private int rotationStep = 10;
        private float resizeStepX = 0;
        private float resizeStepY = 0;

        private Vector3 currentRotation, targetRotation;

        private GameObject card;

        public void RotateToImage(string buttonName)
        {
            rotationDirection = -1;

            card = GameObject.Find(buttonName);
            //cardField.transform.eulerAngles = new Vector3(0, 0, 90);

            //Debug.Log("ROTATION STARTED");

            //GameObject cardField = GameObject.Find("Cards");

            currentRotation = card.transform.eulerAngles;
            targetRotation.y = (currentRotation.y + (180 * rotationDirection));
            StartCoroutine(StartRotation(buttonName));

        }

        IEnumerator StartRotation(string buttonName)
        {
            yield return new WaitForSeconds(2);
            StartCoroutine(ObjectRotationAnimation(buttonName));
        }

        IEnumerator ObjectRotationAnimation(string buttonName)
        {
            currentRotation.y += (rotationStep * rotationDirection);
            card.transform.eulerAngles = currentRotation;
            yield return new WaitForSeconds(0);
            if (((int)currentRotation.y >
            (int)targetRotation.y && rotationDirection < 0) || // for clockwise
            ((int)currentRotation.y < (int)targetRotation.y && rotationDirection > 0)) // for anti-clockwise
            {
                if (currentRotation.y == 90)
                {
                    Button btn = (Button)GameObject.Find(buttonName).GetComponent(typeof(Button));
                    btn.image.sprite = Resources.Load<Sprite>("cardBackground");
                    
                }
                StartCoroutine(ObjectRotationAnimation(buttonName));
                Debug.Log("CORUTINE STARTED");

            }
            else
            {
                //card.transform.eulerAngles = targetRotation;
                Debug.Log("ROTATION ENDED");
                card = null;

            }
        }

        #endregion
    }

}