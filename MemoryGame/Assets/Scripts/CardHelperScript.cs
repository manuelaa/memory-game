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

        IEnumerator CardRotation(float seconds, string buttonName)
        {
            yield return new WaitForSeconds(seconds);
            Button btn = (Button)GameObject.Find(buttonName).GetComponent(typeof(Button));
            btn.image.sprite = Resources.Load<Sprite>("cardBackground");
        }

    }

}