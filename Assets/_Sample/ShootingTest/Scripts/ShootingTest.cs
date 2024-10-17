using MyFPS;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sample
{
    public class ShootingTest : MonoBehaviour
    {
        [SerializeField] private Transform hitEffect;
        [SerializeField] private float impactForce = 10f;

        public ParticleSystem pistolFire;
        public AudioSource shootSound;

        //public Transform camera;
        public Transform firePoint;

        [SerializeField] private float fireDelay = 0.5f;
        private bool isFire = false;

        [SerializeField] private float attackDamage = 5f;

        Animator animator;

        // Start is called before the first frame update
        void Start()
        {
            animator = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0) && isFire == false)
            {
                StartCoroutine(Shoot());

            }
        }

        IEnumerator Shoot()
        {
            isFire = true;

            float maxdis = 100f;

            RaycastHit hit;

            if (Physics.Raycast(firePoint.position, firePoint.TransformDirection(Vector3.forward), out hit, maxdis))
            {
                Transform tmp_effect = Instantiate(hitEffect, hit.point, Quaternion.identity);

                Destroy(tmp_effect.gameObject, 2f);

                if (hit.rigidbody != null)
                {
                    hit.rigidbody.AddForce(-hit.normal * impactForce, ForceMode.Impulse);
                }

                IDamage robotCon = hit.transform.GetComponent<IDamage>();

                if (robotCon != null)
                {
                    robotCon.TakeDamage(attackDamage);
                }


            }

            pistolFire.gameObject.SetActive(true);
            pistolFire.Play();

            animator.SetTrigger("Fire");

            shootSound.Play();

            yield return new WaitForSeconds(fireDelay);

            pistolFire.Stop();
            pistolFire.gameObject.SetActive(false);

            isFire = false;
        }

        private void OnDrawGizmosSelected()
        {
            float maxdis = 100f;
            RaycastHit hit;
            Gizmos.color = Color.red;
            bool isHit = Physics.Raycast(firePoint.position, firePoint.TransformDirection(Vector3.forward), out hit);

            if (isHit)
            {
                Gizmos.DrawRay(firePoint.position, firePoint.forward * hit.distance);
            }
            else
            {
                Gizmos.DrawRay(transform.position, transform.forward * maxdis);
            }
        }

    }
}