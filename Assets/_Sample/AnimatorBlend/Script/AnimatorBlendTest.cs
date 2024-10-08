using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sample
{
    public class AnimatorBlendTest : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 5f;
        private float moveX;
        private float moveY;

        Animator animator;

        // Start is called before the first frame update
        void Start()
        {
            animator = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            Move();
        }

        void Move()
        {
            moveX = Input.GetAxis("Horizontal");
            moveY = Input.GetAxis("Vertical");

            Vector3 pos = new Vector3 (moveX, 0, moveY);

            transform.Translate(pos.normalized * Time.deltaTime * moveSpeed, Space.World);
            //AnimatorState();
            SetBlend();

        }

        void AnimatorState()
        {

            if (moveX > 0)
            {
                //transform.Translate(Vector3.right * Time.deltaTime * moveSpeed, Space.World);
                animator.SetInteger("MoveState", 4);
            }
            else if (moveX < 0)
            {
                //transform.Translate(Vector3.left * Time.deltaTime * moveSpeed, Space.World);
                animator.SetInteger("MoveState", 3);
            }

            else if (moveY > 0)
            {
                //transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
                animator.SetInteger("MoveState", 1);
            }
            else if (moveY < 0)
            {
                //transform.Translate(Vector3.back * Time.deltaTime * moveSpeed, Space.World);
                animator.SetInteger("MoveState", 2);
            }
            else
            {
                animator.SetInteger("MoveState", 0);
            }
        }

        void SetBlend()
        {
            if (moveX > 0)
            {
                animator.SetFloat("MoveX", moveX);
            }
            if (moveX < 0)
            {
                animator.SetFloat("MoveX", moveX);
            }
            if (moveY > 0)
            {
                animator.SetFloat("MoveY", moveY);
            }
            if (moveY < 0)
            {
                animator.SetFloat("MoveY", moveY);
            }
            if(moveX == 0f && moveY == 0f)
            {
                animator.SetFloat("MoveX", 0);
                animator.SetFloat("MoveY", 0);
            }
        }
    }

}
