using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace MyFPS
{
    public class GetPistol : Interactive
    {
        [SerializeField] private GameObject playerPistol;
        [SerializeField] private GameObject arrow;
        [SerializeField] private GameObject arrow2;
        [SerializeField] private GameObject ammoBox;
        [SerializeField] private GameObject enemyTrigger;
        protected override void Action()
        {
            base.Action();
            playerPistol.SetActive(true);
            arrow.SetActive(false);
            enemyTrigger.SetActive(true);
            arrow2.SetActive(true);
            ammoBox.SetActive(true);
            Destroy(gameObject);
        }

    }
}