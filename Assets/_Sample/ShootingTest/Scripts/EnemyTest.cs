using MyFPS;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sample
{
    public class EnemyTest : MonoBehaviour, IDamage
    {
        [SerializeField] private float maxHp = 100f;
        private float currentHp;

        private bool isDeath = false;

        // Start is called before the first frame update
        void Start()
        {
            currentHp = maxHp;
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void TakeDamage(float damage)
        {
            currentHp -= damage;

            Debug.Log(currentHp);

            if(currentHp <= 0 && isDeath == false)
            {
                isDeath = true;

                Die();
            }
            
        }

        void Die()
        {
            isDeath = true;

            Destroy(gameObject, 3f);
        }
    }
}