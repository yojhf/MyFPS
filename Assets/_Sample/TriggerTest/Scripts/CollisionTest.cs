using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sample
{
    public class CollisionTest : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.name == "Player")
            {
                collision.transform.GetComponent<MoveObject>().MovePos(Vector3.left, 2f);
            }


        }

        private void OnCollisionStay(Collision collision)
        {

        }

        private void OnCollisionExit(Collision collision)
        {
            if (collision.gameObject.name == "Player")
            {
                collision.transform.GetComponent<MoveObject>().MovePos(Vector3.left, 2f);
            }

        }
    }
}