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
            if (Vector2.Distance(m_player.transform.position,
                     transform.position) <= attackDistance)
            {
                m_anim.SetBool(Const.ATTACK_ANIMATION, true);
                m_rb.velocity = Vector2.zero;
            }
            else
            {
                m_rb.velocity = new Vector2(-speed, m_rb.velocity.y);
            }
        }
    }

}
