using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace MyFPS
{
    public enum RobotState
    {
        R_Idle,
        R_Walk,
        R_Attack,
        R_Death
    }


    public class RobotCon : MonoBehaviour
    {
        public GameObject player;

        public RobotState robotState;

        private RobotState beforeState;

        [SerializeField] private float maxHealth = 20f;
        private float currentHealth;

        private bool isDeath = false;

        [SerializeField] private float moveSpeed = 2f;

        [SerializeField] private float attackRange = 1.5f;
        [SerializeField] private float attackDamage = 5f;
        [SerializeField] private float attackTimer = 2f;
        private float countDown;

       

        Animator animator;

        // Start is called before the first frame update
        void Start()
        {
            Init();
        }

        // Update is called once per frame
        void Update()
        {
            if(isDeath == true)
            {
                return;
            }

            ChangeState();
        }

        void Init()
        {
            animator = GetComponent<Animator>();

            SetState(RobotState.R_Idle);

            currentHealth = maxHealth;
        }

        void ChangeState()
        {
            float distance = Vector3.Distance(player.transform.position, transform.position);

            if (distance <= attackRange)
            {
                SetState(RobotState.R_Attack);
            }

            switch (robotState)
            {
                case RobotState.R_Idle:

                    break;
                case RobotState.R_Walk:
                    Move();
                    RobotRot();
                    break;
                case RobotState.R_Attack:
                    if (distance > attackRange)
                    {
                        SetState(RobotState.R_Walk);
                    }
                    break;
                //case RobotState.R_Death:
                //    break;

            }
        }

        public void SetState(RobotState state)
        {
            if (robotState == state)
            {
                return;
            }

            robotState = state;
            animator.SetInteger("RobotState", (int)state);
        }

        public void TakeDamage(float damage)
        {
            currentHealth -= damage;

            Debug.Log(currentHealth);

            if(currentHealth <= 0 && isDeath == false)
            {
                Die();
            }
        }

        void Die()
        {
            isDeath = true;

            SetState(RobotState.R_Death);
            transform.GetComponent<Collider>().enabled = false;

            

        }

        void Move()
        {
            Vector3 dir = player.transform.position - transform.position;         

            transform.Translate(dir.normalized * Time.deltaTime * moveSpeed, Space.World);    
        }

        void RobotRot()
        {
            transform.LookAt(player.transform.position);
        }

        void AttackCoolTime()
        {
            if(countDown > attackTimer)
            {
                countDown = 0;
            }
            countDown += Time.deltaTime;
        }

        public void EnemyAttack()
        {
            PlayerCon playerCon = player.transform.GetComponent<PlayerCon>();

            if (playerCon != null)
            {
                playerCon.TakeDamage(attackDamage);
            }

        }

    }
}