using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

namespace MyFPS
{
    public class DoorCon : MonoBehaviour
    {
        [SerializeField] private GameObject actionUI;
        [SerializeField] private GameObject crossHair;
        [SerializeField] private string actionText = "Open the Door";
        [SerializeField] private Transform soundObject;
        public bool isOpen = false;
        Animator animator;

        // Start is called before the first frame update
        void Start()
        {
            animator = GetComponent<Animator>();
            
        }

        // Update is called once per frame
        void Update()
        {
            //DoorOpen();
        }

        private void OnMouseOver()
        {
            if(RayCon.length <= 2f)
            {
                actionUI.SetActive(true);
                crossHair.SetActive(true);
                actionUI.transform.GetChild(1).GetComponent<TMP_Text>().text = actionText;

                if(Input.GetButtonDown("Action"))
                {
                    animator.SetBool("isOpen", true);
                    transform.GetComponent<Collider>().enabled = false;
                    soundObject.GetComponent<AudioSource>().Play();
                    actionUI.SetActive(false);
                    crossHair.SetActive(false);
                }
            }
        }
        private void OnMouseExit()
        {
            actionUI.SetActive(false);
            crossHair.SetActive(false);
        }

        void DoorOpen()
        {
            if(isOpen == true)
            {
                actionUI.SetActive(true);
                actionUI.transform.GetChild(1).GetComponent<TMP_Text>().text = actionText;

                if (Input.GetKeyDown(KeyCode.E))
                {
                    animator.SetBool("isOpen", true);
                    transform.GetComponent<Collider>().enabled = false;
                    isOpen = false;
                }
            }
            else
            {
                actionUI.SetActive(false);
                
            }
        }



        
    }

}
