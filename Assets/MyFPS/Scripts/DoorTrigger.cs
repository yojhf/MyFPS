using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFPS
{
    public class DoorTrigger : MonoBehaviour
    {
        [SerializeField] private GameObject player;
        [SerializeField] private GameObject door;
        Animator animator;
        // Start is called before the first frame update
        void Start()
        {
            animator = door.GetComponent<Animator>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.CompareTag("Player"))
            {
                StartCoroutine(DoorOpen());
            }
        }

        IEnumerator DoorOpen()
        {
            player.SetActive(false);

            yield return new WaitForSeconds(1f);

            animator.SetBool("isOpen", true);
            player.SetActive(true);
            Destroy(gameObject);
        }
    }
}