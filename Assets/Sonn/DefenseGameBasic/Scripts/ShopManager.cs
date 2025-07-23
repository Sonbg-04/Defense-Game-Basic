using Sonn.DefenseGameBasic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sonn.DefenseGameBasic
{
    public class ShopManager : MonoBehaviour
    {
        public ShopItem[] items;

        void Start()
        {
            Init();
        }

        private void Init()
        {
            if (items == null || items.Length <= 0)
            {
                return;
            }    
            for (int i = 0; i < items.Length; i++)
            {
                var item = items[i];
                string key = Const.PLAYER_PREFIX_PREF + i; // player_0, player_1, player_2, etc.
                if (item != null)
                {
                    if (i == 0)
                    {
                        Pref.SetBool(key, true);
                    }
                    else
                    {
                        if (!PlayerPrefs.HasKey(key))
                        {
                            Pref.SetBool(key, false);
                        }    
                    }    
                }    
            }    
        }    
    }

}
