using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

namespace MyFPS
{
    public enum EnemyState
    {
        E_Idle,
        E_Walk,
        E_Attack,
        E_Death,
        E_Chase
    }

    public class EnemyGunCon : RobotCon, IDamage
    {
        public EnemyState enemyState;
        private EnemyState e_beforeState;

        public List<Transform> wayPoints = new List<Transform>();
        public Transform wayPoint;
        private int nowWayPoint = 0;

        private Vector3 startPos;

        NavMeshAgent agent;


        //protected override void Update()
        //{
        //    base.Update();
        //}

        protected override void Init()
        {
            agent = GetComponent<NavMeshAgent>();
            animator = GetComponent<Animator>();

            player = GameObject.Find("PlayerCapsule").gameObject;
   

            for(int i = 0; i < wayPoint.childCount; i++)
            {
                wayPoints.Add(wayPoint.GetChild(i));  
            }


            currentHealth = maxHealth;


            startPos = transform.position;

            if(wayPoints.Count > 0)
            {
                E_SetState(EnemyState.E_Walk);
                GoNextPoint();
            }
            else
            {
                E_SetState(EnemyState.E_Idle);
            }



        }

        protected override void ChangeState()
        {
            float distance = Vector3.Distance(player.transform.position, transform.position);

            if (distance <= attackRange)
            {
                E_SetState(EnemyState.E_Attack);
            }

            switch (enemyState)
            {
                case EnemyState.E_Idle:

                    break;
                case EnemyState.E_Walk:
                    if (agent.remainingDistance <= 0.2f)
                    {
                        GoNextPoint();
                    }
                    else
                    {
                        E_SetState(EnemyState.E_Walk);
                    }
                    break;
                case EnemyState.E_Attack:
                    RobotRot();
                    if (distance > attackRange)
                    {
                        E_SetState(EnemyState.E_Chase);
                    }
                    break;
                case EnemyState.E_Chase:
                    agent.SetDestination(player.transform.position);
                    break;

            }
        }

        protected override void Die()
        {
            isDeath = true;

            E_SetState(EnemyState.E_Death);
            transform.GetComponent<Collider>().enabled = false;
        }

        public void E_SetState(EnemyState state)
        {
            if (enemyState == state)
            {
                return;
            }

            e_beforeState = enemyState;

            enemyState = state;

            if(enemyState == EnemyState.E_Chase)
            {
                animator.SetInteger("EnemyGunState", 1);
                animator.SetLayerWeight(1, 1);
            }
            else
            {
                animator.SetInteger("EnemyGunState", (int)state);
                animator.SetLayerWeight(1, 0);
            }

            agent.ResetPath();
        }

        void GoNextPoint()
        {
            nowWayPoint++;

            if(nowWayPoint >= wayPoints.Count)
            {
                nowWayPoint = 0;
            }

            agent.SetDestination(wayPoints[nowWayPoint].position);
        }
    }
}