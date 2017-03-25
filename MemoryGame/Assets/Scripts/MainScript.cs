using System;
using UnityEngine;
using System.Collections;
using Assets.Scripts.Models;
using Assets.Scripts.Unity;
using UnityEngine.UI;

public class MainScript : MonoBehaviour
{
    private Game _game;
    
    // Use this for initialization
    void Start ()
    {
        _game = new Game(new CardUnityBehaviour(), new PlayerUnityBehaviour(),  2);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void CardChanges()
    {
        _game.CardChanges();
    }

    public void PlayerChanges()
    {
        _game.PlayerChanges();
    }

}
