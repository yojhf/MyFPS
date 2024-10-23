using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sample
{
    public class PlayerMove : MonoBehaviour
    {
        private Vector3 inputDirection = Vector3.zero;

        public float forwardSpeed = 5f;
        public float speed = 5f;

        Rigidbody rb;

        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void Update()
        {
            // move 입력처리
            inputDirection = Vector3.zero;

            inputDirection.x = Input.GetAxis("Horizontal");
        }

        private void LateUpdate()
        {
            rb.AddForce(Vector3.forward * forwardSpeed, ForceMode.Force);

            Move();
        }

        void Move()
        {         
            rb.velocity = inputDirection * speed;

            rb.AddForce(rb.velocity, ForceMode.Force);
        }
    }
}