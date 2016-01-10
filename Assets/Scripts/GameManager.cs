using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static GameManager manager;

	public string[] suffixes;

	public bool scientificNotation;

	public GameObject[] menus;
	public Button[] buttons;

	public void menuActive(GameObject menuClicked, Button buttonClicked) {
		for (int i = 0; i < menus.Length; i++) {
			menus [i].SetActive (false);
			buttons[i].interactable = true;
		}
		menuClicked.SetActive (true);
		buttonClicked.interactable = false;

	}
	public string numberRound(double number) {
		if (scientificNotation)
		{
			return number.ToString("E3");
		}
		else {
			double newNumber = number;
			int i = 0;
			while (newNumber > 1000)
			{
				newNumber /= 1000;
				i++;
			}
			if (i >= suffixes.Length)
			{
				return number.ToString("E3");
			}
			else {
				return newNumber.ToString("N2") + suffixes[i];
			}
		}
	}

    public static void SetDouble(string key, double value)
    {
        PlayerPrefs.SetString(key, DoubleToString(value));
    }
    public static double GetDouble(string key, double defaultValue)
    {
        string defaultVal = DoubleToString(defaultValue);
        return StringToDouble(PlayerPrefs.GetString(key, defaultVal));
    }

    private static string DoubleToString(double target)
    {
        return target.ToString("R");
    }
    private static double StringToDouble(string target)
    {
        if (string.IsNullOrEmpty(target))
            return 0d;

        return double.Parse(target);
    }

    public static void SetUlong(string key, ulong value)
    {
        PlayerPrefs.SetString(key, UlongToString(value));
    }
    public static ulong GetUlong(string key, ulong defaultValue)
    {
        string defaultVal = UlongToString(defaultValue);
        return StringToUlong(PlayerPrefs.GetString(key, defaultVal));
    }
    private static string UlongToString(ulong target)
    {
        return target.ToString();
    }
    private static ulong StringToUlong(string target)
    {
        if (string.IsNullOrEmpty(target))
            return 0;

        return ulong.Parse(target);
    }
}
