using UnityEngine;
using UnityEngine.AI;

public class enemy : MonoBehaviour
{
    public Transform player; 
    private NavMeshAgent navMeshAgent;
     public float speed = 3f;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.speed = speed;
    }

    void Update()
    {
        
        if (player != null)
        {
            navMeshAgent.SetDestination(player.position);

            
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, 1f))
            {
                
                if (!hit.collider.CompareTag("Player"))
                {
                    
                    Vector3 randomDirection = Random.insideUnitSphere * 5f;
                    randomDirection += transform.position;
                    NavMeshHit navHit;
                    NavMesh.SamplePosition(randomDirection, out navHit, 5f, NavMesh.AllAreas);
                    navMeshAgent.SetDestination(navHit.position);
                }
            }
        }
    }


    void OnCollisionEnter(Collision collision)
    {
        /
        if (collision.gameObject.CompareTag("Player"))
        {
            
            Debug.Log("Tu as perdu!");
            
            Application.Quit();
        }
    }
     void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("gome"))
        {
            
            Physics.IgnoreCollision(GetComponent<Collider>(), other.GetComponent<Collider>(), true);
        }
    }
}
