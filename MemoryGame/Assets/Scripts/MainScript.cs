using UnityEngine;
using System.Collections;
using Assets.Scripts.Models;
using Assets.Scripts.Unity;
using UnityEngine.UI;

public class MainScript : MonoBehaviour
{
    private Game Game;
    
    // Use this for initialization
    void Start ()
    {
        var bla = new PlayerUnityBehaviour();
        Game = new Game(new CardUnityBehaviour(), new PlayerUnityBehaviour(),  2);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    
}
