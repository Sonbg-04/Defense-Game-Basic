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
                if (itemUIClone.btn)
                {
                    itemUIClone.btn.onClick.RemoveAllListeners();
                    itemUIClone.btn.onClick.AddListener(() => ItemEvent(item, idx));
                }    
            }    
        }
        public void ClearChilds()
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
        private void ItemEvent(ShopItem item, int itemIdx)
        {
            if (item == null)
            {
                return;
            }    
            bool isUnlocked = Pref.GetBool(Const.PLAYER_PREFIX_PREF + itemIdx);
            if (isUnlocked)
            {
                if (itemIdx == Pref.curPlayerId)
                {
                    return;
                }    
                Pref.curPlayerId = itemIdx;
                UpdateUI();
            }
            else if (Pref.coins >= item.price)
            {
                Pref.coins -= item.price;
                Pref.SetBool(Const.PLAYER_PREFIX_PREF + itemIdx, true);
                Pref.curPlayerId = itemIdx;
                UpdateUI();
                if (m_game.guiManager)
                {
                    m_game.guiManager.UpdateMainCoins();
                }
            }
            else
            {
                Debug.Log("Bạn không đủ tiền để mua!");
            }    
        }    
    }
}

