using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Sonn.DefenseGameBasic
{
    public class GameOverDialog : Dialog, IComponentChecking
    {
        public TextMeshProUGUI bestScoreTxt;

        private AudioManager m_audioManager;


        public override void Show(bool isShow)
        {
            base.Show(isShow);
            m_audioManager = FindObjectOfType<AudioManager>();
            if (bestScoreTxt)
            {
                bestScoreTxt.text = Pref.bestScore.ToString("0000");
            }
        }

        public void RePlay()
        {
            if (IsComponentsNull())
            {
                return;
            }
            CloseDialog();
            SceneManager.LoadScene(Const.GAME_PLAY_SCREEN);
        }  
        
        public void QuitGame()
        {
            Application.Quit();
        }

        public bool IsComponentsNull()
        {
            return m_audioManager == null;
        }
    }

}
