using System;
using UnityEngine;
using System.Collections;
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

    public int rotationDirection = -1; // -1 for clockwise, 1 for anti-clockwise
    public int rotationStep = 10;

    private Vector3 currentRotation, targetRotation;


    public void Rotate()
    {
        //RectTransform cardField = (RectTransform)GameObject.Find("Cards").GetComponent(typeof(RectTransform));
        //cardField.transform.eulerAngles = new Vector3(0, 0, 90);

        GameObject cardField = GameObject.Find("Cards");

        currentRotation = cardField.transform.eulerAngles;
        targetRotation.z = (currentRotation.z + (90 * rotationDirection));
        StartCoroutine(objectRotationAnimation());

    }

    IEnumerator objectRotationAnimation()
    {
        // add rotation step to current rotation.
        currentRotation.z += (rotationStep * rotationDirection);
        gameObject.transform.eulerAngles = currentRotation;
        yield return new WaitForSeconds(5);
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

    public void Exit()
    {
        Debug.Log("QUIT");

        Application.Quit();
    }

}
