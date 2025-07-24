using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Sonn.DefenseGameBasic
{
    public class PauseDialog : Dialog, IComponentChecking
    {
        public override void Show(bool isShow)
        {
            Time.timeScale = 0f;
            base.Show(isShow);
            if (IsComponentsNull())
            {
                return;
            }
            AudioManager.Ins.PauseMusic(AudioManager.Ins.musicSource);
        }

        public override void CloseDialog()
        {
            Time.timeScale = 1f;
            base.CloseDialog();
        }
        public void ResumeGame()
        {
            if (IsComponentsNull())
            {
                return;
            }
            CloseDialog();
            AudioManager.Ins.ResumeMusic(AudioManager.Ins.musicSource);
        }
        public void Replay()
        {
            if (IsComponentsNull())
            {
                return;
            }
            CloseDialog();
            SceneManager.LoadScene(Const.GAME_PLAY_SCREEN);
            
        }

        public bool IsComponentsNull()
        {
            return AudioManager.Ins == null;
        }
    }

}
