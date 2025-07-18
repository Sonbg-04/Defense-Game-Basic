using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sonn.DefenseGameBasic
{
    public class Enemy : MonoBehaviour, IComponentChecking
    {
        public float speed;
        public float attackDistance;

        private Animator m_anim;
        private Rigidbody2D m_rb;
        private Player m_player;

        public bool IsComponentsNull()
        {
            return m_anim == null || m_rb == null || m_player == null;
        }

        private void Awake()
        {
            m_anim = GetComponent<Animator>();
            m_rb = GetComponent<Rigidbody2D>();
            m_player = FindObjectOfType<Player>();
        }

        void Update()
        {
            if (IsComponentsNull())
            {
                return;
            }

            float distanceToPlayer = Vector2.Distance(m_player.transform.position,
                transform.position);
            
            if (distanceToPlayer <= attackDistance)
            {
                m_anim.SetBool(Const.ATTACK_ANIMATION, true);
                m_rb.velocity = Vector2.zero;
            }
            else
            {
                m_rb.velocity = new Vector2(-speed, m_rb.velocity.y);
            }

            //if (m_player.isDead)
            //{
            //    m_anim.SetBool(Const.ATTACK_ANIMATION, false);
            //    m_rb.velocity = Vector2.zero;
            //}
        }
        public void Die()
        {
            if (IsComponentsNull())
            {
                return;
            }

            m_anim.SetTrigger(Const.DEAD_ANIMATION);
            m_rb.velocity = Vector2.zero;
            gameObject.layer = LayerMask.NameToLayer(Const.DEAD_LAYER);
        }    
    }

}
