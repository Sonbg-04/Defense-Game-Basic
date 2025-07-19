using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sonn.DefenseGameBasic
{
    public class Player : MonoBehaviour, IComponentChecking
    {
        public float attackRate;
        public bool isDead;

        private Animator m_anim;
        private float m_curAttackrate;
        private bool m_isAttacked;
        

        private void Awake()
        {
            m_anim = GetComponent<Animator>();
            m_curAttackrate = attackRate;
        }

        void Update()
        {
            if (IsComponentsNull())
            {
                return;
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.localScale = new Vector3(1, 1, 1);
                transform.position += 5f * Time.deltaTime * Vector3.left;
            }    
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.localScale = new Vector3(-1, 1, 1);
                transform.position += 5f * Time.deltaTime * Vector3.right;
            }

            if (Input.GetMouseButtonDown(0) || Input.GetKey(KeyCode.T) && !m_isAttacked)
            {
                m_anim.SetBool(Const.ATTACK_ANIMATION, true);
                m_isAttacked = true;
            }
            if (m_isAttacked)
            {
                m_curAttackrate -= Time.deltaTime;
                if (m_curAttackrate <= 0)
                {
                    m_isAttacked = false;
                    m_curAttackrate = attackRate;
                }
            }
        }

        public void Reset_Attack_Animator()
        {
            if (IsComponentsNull())
            {
                return;
            }
            m_anim.SetBool(Const.ATTACK_ANIMATION, false);
        }

        public bool IsComponentsNull()
        {
            return m_anim == null;
        }
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (IsComponentsNull())
            {
                return;
            }
            
            if (col.CompareTag(Const.ENEMY_WEAPON_TAG) && !isDead)
            {
                m_anim.SetTrigger(Const.DEAD_ANIMATION);
                isDead = true;
            }     
        }
    }

}

