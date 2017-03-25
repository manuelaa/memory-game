using UnityEngine;
using System.Collections;
using Assets.Scripts.Models;
using UnityEngine.EventSystems;
using UnityEngine.Networking;
using UnityEngine.UI;

public class CardsScript : MonoBehaviour
{
    public Image PrefabImage;
    private MainScript mainScript;
    private Card card;

    public CardsScript()
    {
        
    }

	// Use this for initialization
	void Start () {
        GameObject cameraGameObject = GameObject.Find("Camera");
        mainScript = (MainScript)cameraGameObject.GetComponent(typeof(MainScript));

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void DrawCard(Card _card, float x, float y, float z)
    {
        //Canvas go = (Canvas)GameObject.Find("Cards").GetComponent<Canvas>();
        GameObject gameObject = GameObject.Find("Cards");
        Image image = Instantiate(PrefabImage) as Image;
        image.transform.position = new Vector3(x,y,z);
        image.transform.SetParent(gameObject.transform, false);
        card = _card;
    }

    public void OnClick()
    {
        Debug.Log("CLICKED");
        //main. ...
        
        Debug.Log(EventSystem.current.currentSelectedGameObject.name);
    }
}
