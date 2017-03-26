using UnityEngine;
using System.Collections;
using Assets.Scripts.Models;
using UnityEngine.EventSystems;
using UnityEngine.Networking;
using UnityEngine.UI;

public class CardsScript : MonoBehaviour
{
    public Image PrefabImage;
    public Button ButtonPrefab;
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
        GameObject gameObject = GameObject.Find("Cards");

        Button btn = Instantiate(ButtonPrefab) as Button;
        btn.transform.position = new Vector3(x, y, z);
        btn.onClick.AddListener(() => OnClick());
        btn.transform.SetParent(gameObject.transform, false);
        //btn.gameObject.AddComponent("CardScript") as CardsScript;

        card = _card;
    }

    public void OnClick()
    {
        Debug.Log("CLICKED" + card.Name);
        //main. ...

        //Debug.Log(EventSystem.current.currentSelectedGameObject.name);
    }
}
