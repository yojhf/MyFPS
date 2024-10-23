using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sample
{
    public class CameraCon : MonoBehaviour
    {
        [SerializeField] private Transform player;
        [SerializeField] private Vector3 offset = Vector3.zero;

        private void LateUpdate()
        {
            FollowCamera();
        }

        void FollowCamera()
        {
            transform.position = player.position + offset;

        }
    }

}
