using System.Collections;
using System.Collections.Generic;
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
        public RobotState robotState;

        private RobotState beforeState;

        [SerializeField] private float startHealth = 20f;

        Animator animator;
        // Start is called before the first frame update
        void Start()
        {
            animator = GetComponent<Animator>();

            SetState(RobotState.R_Idle);
        }

        // Update is called once per frame
        void Update()
        {

        }

        void SetState(RobotState state)
        {
            if (robotState == state)
            {
                return;
            }

            robotState = state;
            animator.SetInteger("RobotState", (int)state);

            //switch (robotState)
            //{
            //    case RobotState.R_Idle:
            //        {
            //            break;
            //        }
            //}    
  
        }
    }
}