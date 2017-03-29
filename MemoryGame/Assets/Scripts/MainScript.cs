using System;
using UnityEngine;
using System.Collections;
using Assets.Scripts;
using Assets.Scripts.Models;
using Assets.Scripts.Unity;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainScript : MonoBehaviour
{
    private Game _game;

    public GameObject WinScreen;
    public GameObject btnYes;
    public GameObject btnNo;
    public Text Text;

    public MainScript()
    {
        
    }

    // Use this for initialization
    void Start ()
    {
        // 15 je max karata
        // 4 je max igrača

        var playersNumber = MenuScript.PlayersNumber == 0 ? 4 : MenuScript.PlayersNumber;
        var cardsNumber = MenuScript.CardsNumber == 0 ? 15 : MenuScript.CardsNumber;

        WinScreen.SetActive(false);
        RectTransform cardField = (RectTransform)GameObject.Find("Cards").GetComponent(typeof(RectTransform));
        _game = new Game(new GameUnityBehaviour(), new CardUnityBehaviour(), new PlayerUnityBehaviour(), playersNumber, cardsNumber, cardField.rect.width, cardField.rect.height);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }

    public void CardChanges(int cardId)
    {
        _game.CardChanges(cardId);

        if (_game.CheckEnd())
        {
            WinScreen.SetActive(true);
            Text.text = _game.GetWinner() + " is winner! \nContinue?";
        }

    }

    public void PlayAgain()
    {
        _game.Reset();
        WinScreen.SetActive(false);
    }


    public void Exit()
    {
        Debug.Log("QUIT");

        Application.Quit();
    }

    public void Rotate()
    {
        GameObject helpGo = GameObject.Find("HelperGameObject");
        var cardHelperScript = (CardHelperScript)helpGo.GetComponent(typeof(CardHelperScript));

        cardHelperScript.Rotate("TestCard", "eighteen");
    }

}
