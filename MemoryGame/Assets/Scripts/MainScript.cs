using System;
using UnityEngine;
using System.Collections;
using Assets.Scripts.Models;
using Assets.Scripts.Unity;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Script attached to Camera object on MainScene
/// </summary>
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
        var cardsNumber = MenuScript.CardsNumber == 0 ? 4 : MenuScript.CardsNumber;
        var rotationAllowed = MenuScript.RotationAllowed;

        WinScreen.SetActive(false);
        RectTransform cardField = (RectTransform)GameObject.Find("Cards").GetComponent(typeof(RectTransform));
        _game = new Game(new GameUnityBehaviour(), new CardUnityBehaviour(), new PlayerUnityBehaviour(), playersNumber, cardsNumber, rotationAllowed, cardField.rect.width, cardField.rect.height);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }

    /// <summary>
    /// Handles event of card changes
    /// </summary>
    /// <param name="cardId"></param>
    public void CardChanges(int cardId)
    {
        _game.CardChanges(cardId);

        if (_game.CheckEnd())
        {
            WinScreen.SetActive(true);
            Text.text = "Winner is ..." + _game.GetWinner() + "! \nDo You want to continue?";
        }

    }

    /// <summary>
    /// Play memory againe from begining.
    /// Attached to button YES in "win screen"
    /// </summary>
    public void PlayAgain()
    {
        _game.Reset();
        WinScreen.SetActive(false);
    }

    /// <summary>
    /// Ends application
    /// </summary>
    public void Exit()
    {
        Debug.Log("QUIT");

        Application.Quit();
    }

    /// <summary>
    /// Returns to first scene, to menu
    /// </summary>
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    // test functions
    public void CLickRotate()
    {
        _game.Rotate();
    }

    public void CLickResizeAndRotate()
    {
        _game.RotateAndResize();
    }


}
