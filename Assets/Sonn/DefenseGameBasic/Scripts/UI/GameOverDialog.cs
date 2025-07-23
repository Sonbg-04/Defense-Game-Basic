using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Sonn.DefenseGameBasic
{
    public class GameOverDialog : Dialog
    {
        public TextMeshProUGUI bestScoreTxt;

        public override void Show(bool isShow)
        {
            base.Show(isShow);
            if (bestScoreTxt)
            {
                bestScoreTxt.text = Pref.bestScore.ToString("0000");
            }    
        }

        public void RePlay()
        {
            CloseDialog();
            SceneManager.LoadScene(Const.GAME_PLAY_SCREEN);
        }  
        
        public void QuitGame()
        {
            Application.Quit();
        }    
    }

}
