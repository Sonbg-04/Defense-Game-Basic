using Sonn.DefenseGameBasic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sonn.DefenseGameBasic
{
    public class Player : MonoBehaviour
    {
        public float attackRate;
        private Animator m_anim;
        private float m_curAttackrate;
        private bool m_isAttacked;

        private void Awake()
        {
            m_anim = GetComponent<Animator>();
            m_curAttackrate = attackRate;
        }

        void Start()
        {

        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0) && !m_isAttacked)
            {
                if (m_anim)
                {
                    m_anim.SetBool(Const.ATTACK_ANIMATION, true);
                }
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
            if (m_anim)
            {
                m_anim.SetBool(Const.ATTACK_ANIMATION, false);
            }
        }
    }

}

