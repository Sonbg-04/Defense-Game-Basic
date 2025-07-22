using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Sonn.DefenseGameBasic
{
    public class GUIManager : MonoBehaviour
    {
        public GameObject homeGUI, gameGUI;
        public Dialog gameOverDialog;
        public TextMeshProUGUI mainCoinTxt, gamePlayCoinTxt;

        public void ShowGameGUI(bool isShow)
        {
            if (gameGUI)
            {
                gameGUI.SetActive(isShow);
            }
            if (homeGUI)
            {
                homeGUI.SetActive(!isShow);
            }
        }

        public void UpdateMainCoins()
        {
            if (mainCoinTxt)
            {
                mainCoinTxt.text = Pref.coins.ToString();
            }    
        }

        public void UpdateGamePlayCoins()
        {
            if (gamePlayCoinTxt)
            {
                gamePlayCoinTxt.text = Pref.coins.ToString();
            }
        }    
    }
}

