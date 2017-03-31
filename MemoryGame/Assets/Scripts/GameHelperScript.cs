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
        private const float SecondsBeforeRotation = 1.5f;

        private int rotationDirection = -1; // -1 for clockwise, 1 for anti-clockwise
        private int rotationStep = 10;
        private float resizeStepX = 0;
        private float resizeStepY = 0;

        private Vector3 currentRotation, targetRotation, currentScale, targetScale, originalScale;
        private Rect originalSize;

        private RectTransform cardField;

        public void SetOriginalSize()
        {
            cardField = (RectTransform)GameObject.Find("Cards").GetComponent(typeof(RectTransform));
            originalScale = cardField.transform.localScale;
            originalSize = cardField.rect;
        }

        public void ReturnOriginalSize()
        {
            cardField = (RectTransform)GameObject.Find("Cards").GetComponent(typeof(RectTransform));
            cardField.transform.localScale = new Vector3(1,1,1);
        }


        public void Rotate(int degree)
        {
            cardField = (RectTransform)GameObject.Find("Cards").GetComponent(typeof(RectTransform));
            //cardField.transform.eulerAngles = new Vector3(0, 0, 90);

            Debug.Log("ROTATION STARTED");

            //GameObject cardField = GameObject.Find("Cards");

            currentRotation = cardField.transform.eulerAngles;
            targetRotation.z = (currentRotation.z + (degree * rotationDirection));
            //yield return new WaitForSeconds(3);
            //StartCoroutine(ObjectRotationAnimation());
            StartCoroutine(StartRotation());

        }

        IEnumerator StartRotation()
        {
            yield return new WaitForSeconds(SecondsBeforeRotation);
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


        //**********************************************************************************************************************************************


        public void ResizeAndRotate(int degree)
        {
            cardField = (RectTransform)GameObject.Find("Cards").GetComponent(typeof(RectTransform));
            //cardField.transform.eulerAngles = new Vector3(0, 0, 90);

            Debug.Log("ROTATION STARTED");

            //GameObject cardField = GameObject.Find("Cards");

            currentScale = cardField.transform.localScale;

            currentRotation = cardField.transform.eulerAngles;
            var size = 0;
            if (currentRotation.z.Equals(90) || currentRotation.z.Equals(270) || currentRotation.z.Equals(-90) || currentRotation.z.Equals(-270))
            {
                targetScale.x = originalScale.x;
                targetScale.y = originalScale.y;
                size = -1; // povecava se
            }
            else
            {
                // iz vodoravnog u okomito 
                targetScale.x = originalScale.y / (originalSize.width / originalSize.height);
                targetScale.y = 1 / (originalSize.width* currentScale.x / originalSize.height);
                size = +1; // smanjuje se

            }

            //cardField.transform.localScale = targetSize;

            targetRotation.z = (currentRotation.z + (degree * rotationDirection));

            int numSteps = ((int)(Math.Abs(targetRotation.z - currentRotation.z) / rotationStep) - 1);
            resizeStepX = (Math.Abs(targetScale.x - currentScale.x) / (numSteps) * size);
            resizeStepY = Math.Abs(targetScale.y - currentScale.y) / (numSteps) * size;

            StartCoroutine(StartRotationAndResizing());

        }

        IEnumerator StartRotationAndResizing()
        {
            yield return new WaitForSeconds(SecondsBeforeRotation);
            StartCoroutine(ObjectResizingAndRotationAnimation());
        }

        IEnumerator ObjectResizingAndRotationAnimation()
        {
            // add rotation step to current rotation.
            currentRotation.z += (rotationStep * rotationDirection);
            cardField.transform.eulerAngles = currentRotation;

            currentScale.x += resizeStepX;
            currentScale.y += resizeStepY;
            cardField.transform.localScale = currentScale;

            Debug.Log(currentRotation);

            yield return new WaitForSeconds(0);
            if (((int)currentRotation.z >
            (int)targetRotation.z && rotationDirection < 0) || // for clockwise
            ((int)currentRotation.z < (int)targetRotation.z && rotationDirection > 0)) // for anti-clockwise
            {
                StartCoroutine(ObjectResizingAndRotationAnimation());
                Debug.Log("CORUTINE STARTED");

            }
            else
            {
                cardField.transform.eulerAngles = targetRotation;

                cardField.transform.localScale = targetScale;

                Debug.Log("ROTATION ENDED");
                cardField = null;

            }
        }





    }
}
