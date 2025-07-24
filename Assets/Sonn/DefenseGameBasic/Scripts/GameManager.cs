using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sonn.DefenseGameBasic
{
    public class GameManager : MonoBehaviour, IComponentChecking
    {
        public static GameManager Ins;

        public float spawnTime;
        public Enemy[] enemyPrefabs;
        public SettingsDialog settingsDialog;

        private bool m_isGameOver;
        private int m_score;
        private Player m_currentPlayer;

        public int Score { get => m_score; set => m_score = value; }

        private void Awake()
        {
            Ins = this;
        }

        void Start()
        {
            if (IsComponentsNull())
            {
                return;
            }

            GUIManager.Ins.ShowGameGUI(false);
            GUIManager.Ins.UpdateMainCoins();

            settingsDialog.LoadVolumeSettings();

            AudioManager.Ins.PlayMusic(AudioManager.Ins.musicSource);
        }
        public void ActivePlayer()
        {
            if (IsComponentsNull())
            {
                return;
            }

            if (m_currentPlayer)
            {
                Destroy(m_currentPlayer.gameObject);
            }

            var shopItem = ShopManager.Ins.items;
            if (shopItem == null || shopItem.Length <= 0)
            {
                return;
            }  
            
            var newPlayerPrefab = shopItem[Pref.curPlayerId].playerPrefabs;
            if (newPlayerPrefab)
            {
                m_currentPlayer = Instantiate(newPlayerPrefab, new Vector3(-7f, -1f, 0f), Quaternion.identity);

            }    
        }   
        
        public void PlayGame()
        {
            if (IsComponentsNull())
            {
                return;
            }

            ActivePlayer();

            StartCoroutine(SpawnEnemies());

            GUIManager.Ins.ShowGameGUI(true);
            GUIManager.Ins.UpdateGamePlayCoins();
        }

        public void GameOver()
        {
            if (m_isGameOver)
            {
                return;
            }
            m_isGameOver = true;
            Pref.bestScore = m_score;
            if (GUIManager.Ins.gameOverDialog)
            {
                GUIManager.Ins.gameOverDialog.Show(true);
            }
            AudioManager.Ins.PlaySoundOneShots(AudioManager.Ins.gameOverSource);    
        }
        IEnumerator SpawnEnemies()
        {
            while (!m_isGameOver)
            {
                if (enemyPrefabs != null && enemyPrefabs.Length > 0)
                {
                    int randomIndex = Random.Range(0, enemyPrefabs.Length);
                    Enemy enemyPrefab = enemyPrefabs[randomIndex];

                    if (enemyPrefab)
                    {
                        Instantiate(enemyPrefab, new Vector3(8, 0, 0), Quaternion.identity);
                    }
                }

                yield return new WaitForSeconds(spawnTime);
            }    
        }

        public bool IsComponentsNull()
        {
            return GUIManager.Ins == null || ShopManager.Ins == null || AudioManager.Ins == null;
        }
    }
}
