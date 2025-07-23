using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sonn.DefenseGameBasic
{
    public class GameManager : MonoBehaviour, IComponentChecking
    {
        public float spawnTime;
        public Enemy[] enemyPrefabs;
        public GUIManager guiManager;

        private bool m_isGameOver;
        private int m_score;

        public int Score { get => m_score; set => m_score = value; }

        void Start()
        {
            
            if (IsComponentsNull())
            {
                return;
            }
            guiManager.ShowGameGUI(false);
            guiManager.UpdateMainCoins();
        }
        public void PlayGame()
        {
            guiManager.ShowGameGUI(true);
            StartCoroutine(SpawnEnemies());
            guiManager.UpdateGamePlayCoins();
        }
        public void GameOver()
        {
            if (m_isGameOver)
            {
                return;
            }
            m_isGameOver = true;
            Pref.bestScore = m_score;
            if (guiManager.gameOverDialog)
            {
                guiManager.gameOverDialog.Show(true);
            }    
            
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
            return guiManager == null;
        }
    }
}
