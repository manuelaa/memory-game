using System;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Script attached to Camera object on MenuScene.
/// Defines number of players, number of cards and defines if table rotation is allowed.
/// Initializes dropdows.
/// </summary>
public class MenuScript : MonoBehaviour
{
    public static int PlayersNumber = 0;
    public static int CardsNumber = 0;
    public static bool RotationAllowed = true;

    private const int PlayersNumberMin = 2;
    private const int PlayersNumberMax = 4;
    private const int CardsNumberMin = 4;
    private const int CardsNumberMax = 20;

    public Dropdown playersDropdown;
    public Dropdown cardsDropdown;
    public Toggle rotationToggle;

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

    public void RotationToggleValueChanged()
    {
        RotationAllowed = rotationToggle.isOn;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
