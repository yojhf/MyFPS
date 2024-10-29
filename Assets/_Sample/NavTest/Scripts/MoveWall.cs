using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sample
{
    public class MoveWall : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 1f;
        [SerializeField] private float moveTime = 1f;
        private float count = 0f;


        [SerializeField] private float dir = 1f;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            Timer();
            Move();
        }

        void Timer()
        {
            count += Time.deltaTime;

            if (count >= moveTime)
            {
                dir *= -1;

                count = 0f;
            }
        }

        void Move()
        {
            transform.Translate(Vector3.right * dir * Time.deltaTime * moveSpeed, Space.World);
        }

    }
}