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
        protected override void Action()
        {
            base.Action();
            playerPistol.SetActive(true);
            arrow.SetActive(false);
            Destroy(gameObject);
        }

    }
}