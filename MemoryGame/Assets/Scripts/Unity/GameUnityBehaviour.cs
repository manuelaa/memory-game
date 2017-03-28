using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Unity
{
    public class GameUnityBehaviour : MonoBehaviour, IGameBehaviour
    {
        public int rotationDirection = -1; // -1 for clockwise, 1 for anti-clockwise
        public int rotationStep = 10;

        private Vector3 currentRotation, targetRotation;

        public void Rotate()
        {
            RectTransform cardField = (RectTransform)GameObject.Find("Cards").GetComponent(typeof(RectTransform));
            cardField.transform.eulerAngles = new Vector3(0, 0, 90);

            currentRotation = cardField.transform.eulerAngles;
            targetRotation.z = (currentRotation.z + (90 * rotationDirection));
            StartCoroutine(objectRotationAnimation());

        }

        IEnumerator objectRotationAnimation()
        {
            // add rotation step to current rotation.
            currentRotation.z += (rotationStep * rotationDirection);
            gameObject.transform.eulerAngles = currentRotation;
            yield return new WaitForSeconds(0);
            if (((int)currentRotation.z >
            (int)targetRotation.z && rotationDirection < 0) || // for clockwise
            ((int)currentRotation.z < (int)targetRotation.z && rotationDirection > 0)) // for anti-clockwise
            {
                StartCoroutine(objectRotationAnimation());
            }
            else
            {
                gameObject.transform.eulerAngles = targetRotation;
            }
        }

        IEnumerator rotateObjectAgain()
        {
            yield return new WaitForSeconds(0.2f);
            Rotate();
        }
    }
}
