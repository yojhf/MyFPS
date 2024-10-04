using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFPS
{
    public class DoorCon : MonoBehaviour
    {
        private bool isOpen = false;
        Animator animator;

        // Start is called before the first frame update
        void Start()
        {
            animator = GetComponent<Animator>();

            animator.SetBool("isOpen", true);
        }

        // Update is called once per frame
        void Update()
        {

        }

        void DoorOpen()
        {
            if(isOpen == true)
            {
              
            }
        }



        
    }

}
