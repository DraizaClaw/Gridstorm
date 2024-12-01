using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    [SerializeField] private Text CoinAmount;
    [SerializeField] private Text UnlockDashText;

    private void Update()
    {
        CoinAmount.text = ("Coins: " + PlayerPrefs.GetInt("Coins"));
    }
    public void LoadScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }
    public void UnlockDash(int price)
    {

        if (PlayerPrefs.GetInt("Coins") >= price)
        {
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - price);
            PlayerPrefs.SetInt("DashUnlocked", 1);
            UnlockDashText.text = ("Unlock Dash\n Bought");
        }
        else
            UnlockDashText.text = ("Insufficient funds");
        
    }

}
