using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sample
{
    public class TriggerTest : MonoBehaviour
    {

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.name == "Player")
            {
                other.transform.GetComponent<MoveObject>().MovePos(Vector3.right, 2f);
                other.transform.GetComponent<MoveObject>().ChangeColor(Color.red);
            }
        }
        private void OnTriggerStay(Collider other)
        {
            Debug.Log("TriggerStay");
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.name == "Player")
            {
                other.transform.GetComponent<MoveObject>().MovePos(Vector3.right, 2f);
                other.transform.GetComponent<MoveObject>().ResetColor();
            }
        }
    }
}