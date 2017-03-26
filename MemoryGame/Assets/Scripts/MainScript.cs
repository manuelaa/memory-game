using System;
using UnityEngine;
using System.Collections;
using Assets.Scripts.Models;
using Assets.Scripts.Unity;
using UnityEngine.UI;

public class MainScript : MonoBehaviour
{
    private Game _game;

    public GameObject WinScreen;
    public GameObject btnYes;
    public GameObject btnNo;
    public Text Text;

    
    // Use this for initialization
    void Start ()
    {
        WinScreen.SetActive(false);
        _game = new Game(new CardUnityBehaviour(), new PlayerUnityBehaviour(),  2, 6);
    }
	
	// Update is called once per frame
	void Update () {
	
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

}
