using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Sonn.DefenseGameBasic
{
    public class ShopItemUI : MonoBehaviour
    {
        public TextMeshProUGUI priceTxt;
        public Image hud;
        public Button btn;
        public void UpdateUI(ShopItem item, int itemIndex)
        {
            if (item == null)
            {
                return;
            }
            if (hud)
            {
                hud.sprite = item.previewImg;
            }
            bool isUnlocked = Pref.GetBool(Const.PLAYER_PREFIX_PREF + itemIndex);
            if (isUnlocked)
            {
                if (Pref.curPlayerId == itemIndex)
                {
                    if (priceTxt)
                    {
                        priceTxt.text = "Active";
                    }
                    else if (priceTxt)
                    {
                        priceTxt.text = "Owned";
                    }    
                }    
            }
            else
            {
                if (priceTxt)
                {
                    priceTxt.text = item.price.ToString();
                }
            }    
            
        }    
    }
}
