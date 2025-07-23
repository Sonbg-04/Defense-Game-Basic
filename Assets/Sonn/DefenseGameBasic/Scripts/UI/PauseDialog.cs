using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Sonn.DefenseGameBasic
{
    public class PauseDialog : Dialog, IComponentChecking
    {
        private AudioManager m_audioManager;
        public override void Show(bool isShow)
        {
            Time.timeScale = 0f;
            base.Show(isShow);
            m_audioManager = FindObjectOfType<AudioManager>();
            if (IsComponentsNull())
            {
                return;
            }
            m_audioManager.PauseMusic(m_audioManager.musicSource);
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
            m_audioManager.ResumeMusic(m_audioManager.musicSource);
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
            return m_audioManager == null;
        }
    }

}
