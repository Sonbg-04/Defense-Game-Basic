using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Sonn.DefenseGameBasic
{
    public class PauseDialog : Dialog
    {
        public override void Show(bool isShow)
        {
            Time.timeScale = 0f;
            base.Show(isShow);
        }

        public override void CloseDialog()
        {
            Time.timeScale = 1f;
            base.CloseDialog();
        }
        public void ResumeGame()
        {
            CloseDialog();
        }
        public void Replay()
        {
            CloseDialog();
            SceneManager.LoadScene(Const.GAME_PLAY_SCREEN);
        }    
    }

}
