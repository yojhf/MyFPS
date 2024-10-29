using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// 마우스로 그라운드를 클릭하면 클릭한 지점으로 이동
namespace Sample
{
    public class AgentCon : MonoBehaviour
    {
        private Vector3 worldPos;
        
        NavMeshAgent agent;

        // Start is called before the first frame update
        void Start()
        {
            agent = GetComponent<NavMeshAgent>();
        }

        // Update is called once per frame
        void Update()
        {
            ClickMove();
        }

        void ClickMove()
        {
            if(Input.GetMouseButtonDown(0))
            {
                SetDestinationPos();
              
            }
        }

        void SetDestinationPos()
        {
          
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
            }

            
        }
    }


}
