using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFPS
{
    public class EnemyZone : MonoBehaviour
    {
        public Transform enemyGun;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                EnemyGunCon enemyGunCon = enemyGun.GetComponent<EnemyGunCon>();

                if(enemyGunCon != null)
                {
                    enemyGunCon.E_SetState(EnemyState.E_Chase);
                }


            }
        }
    }
}