using Sample;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace MyFPS
{
    public class BFirstTrigger : MonoBehaviour
    {
        [SerializeField] private GameObject arrow;
        [SerializeField] private GameObject player;
        [SerializeField] private TMP_Text openingText;
        [SerializeField] private string opening_text = "Looks like a weapon on that table.";




        IEnumerator FirstTrigger()
        {
            player.SetActive(false);

            openingText.text = opening_text;
            openingText.gameObject.SetActive(true);

            yield return new WaitForSeconds(1f);

            arrow.SetActive(true);

            yield return new WaitForSeconds(1f);

            openingText.text = "";
            openingText.gameObject.SetActive(false);
            player.SetActive(true);
            GetComponent<Collider>().enabled = false;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                StartCoroutine(FirstTrigger());

            }
        }
    }
}