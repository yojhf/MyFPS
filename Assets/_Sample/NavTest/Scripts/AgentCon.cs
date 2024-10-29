using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// ���콺�� �׶��带 Ŭ���ϸ� Ŭ���� �������� �̵�
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
