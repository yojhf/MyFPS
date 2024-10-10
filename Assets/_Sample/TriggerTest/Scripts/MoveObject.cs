using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

namespace Sample
{
    public class MoveObject : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 5f;
        private float moveX;
        private Vector3 pos;
        Rigidbody rb;
        Color resetColor;
        Material material;

        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody>();
            rb.AddForce(Vector3.right * moveSpeed, ForceMode.Impulse);
            material = GetComponent<Renderer>().material;

            resetColor = material.color;
        }

        // Update is called once per frame
        void Update()
        {
            moveX = Input.GetAxis("Horizontal");
        }

        private void FixedUpdate()
        {
            //Move();
        }

        void Move()
        {
            //pos = Vector3.right;

            rb.AddForce(Vector3.right * moveX * moveSpeed, ForceMode.Force);
        }

        public void MovePos(Vector3 pos, float speed )
        {
            rb.AddForce(pos * speed, ForceMode.Impulse);
        }
        public void ChangeColor(Color color)
        {
            material.color = color;
        }

        public void ResetColor()
        {
            material.color = resetColor;
        }



    }
}
