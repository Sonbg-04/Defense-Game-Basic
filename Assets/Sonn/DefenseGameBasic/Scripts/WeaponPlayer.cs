using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sonn.DefenseGameBasic
{
    public class WeaponPlayer : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag(Const.ENEMY_TAG))
            {
                Enemy enemy = col.GetComponent<Enemy>();
                if (enemy)
                {
                    enemy.Die();
                }    
            }    
        }
    }
}
