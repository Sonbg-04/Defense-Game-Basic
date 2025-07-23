using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sonn.DefenseGameBasic
{
    public class ShopDialog : Dialog, IComponentChecking
    {
        public Transform gridRoot;
        public ShopItemUI itemUIPrefabs;

        private ShopManager m_shopManager;
        private GameManager m_game;

        public bool IsComponentsNull()
        {
            return m_shopManager == null || m_game == null || gridRoot == null;
        }

        public override void Show(bool isShow)
        {
            base.Show(isShow);
            m_shopManager = FindObjectOfType<ShopManager>();
            m_game = FindObjectOfType<GameManager>();
            UpdateUI();
        }
        private void UpdateUI()
        {
            if (IsComponentsNull())
            {
                return;
            }
            ClearChilds();
            var items = m_shopManager.items;
            if (items == null || items.Length <= 0)
            {
                return;
            }    
            for (int i = 0; i < items.Length; i++)
            {
                int idx = i;
                var item = items[idx];
                var itemUIClone = Instantiate(itemUIPrefabs, Vector3.zero, Quaternion.identity);
                itemUIClone.transform.SetParent(gridRoot);
                itemUIClone.transform.localScale = Vector3.one;
                itemUIClone.transform.localPosition = Vector3.zero;
                itemUIClone.UpdateUI(item, idx);
            }    
        }
        private void ClearChilds()
        {
            if (gridRoot == null || gridRoot.childCount <= 0)
            {
                return;
            }
            for (int i = 0; i < gridRoot.childCount; i++)
            {
                var child = gridRoot.GetChild(i);
                if (child)
                {
                    Destroy(child.gameObject);
                }    
            }
        }
    }
}

