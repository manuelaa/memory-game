using System;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    public static int PlayersNumber = 0;
    public static int CardsNumber = 0;

    private const int PlayersNumberMin = 2;
    private const int PlayersNumberMax = 4;
    private const int CardsNumberMin = 4;
    private const int CardsNumberMax = 15;

    public Dropdown playersDropdown;
    public Dropdown cardsDropdown;

    // Use this for initialization
    void Start () {
	    for (int i = PlayersNumberMin; i <= PlayersNumberMax; i++)
	    {
            playersDropdown.options.Add(new Dropdown.OptionData() { text = i.ToString() });
        }
        playersDropdown.value = 0;
        playersDropdown.Select();
        playersDropdown.RefreshShownValue();
        PlayersNumber = PlayersNumberMin;

        for (int i = CardsNumberMin; i <= CardsNumberMax; i++)
        {
            cardsDropdown.options.Add(new Dropdown.OptionData() { text = i.ToString() });
        }
        cardsDropdown.value = 0;
        cardsDropdown.Select();
        cardsDropdown.RefreshShownValue();
        CardsNumber = CardsNumberMin;
    }

    // Update is called once per frame
    void Update () {
	
	}

    public void PlayersDropdownValueChanged()
    {
        PlayersNumber = Convert.ToInt32(playersDropdown.options[playersDropdown.value].text);
    }

    public void CardsDropdownValueChanged()
    {
        CardsNumber = Convert.ToInt32(cardsDropdown.options[cardsDropdown.value].text);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
