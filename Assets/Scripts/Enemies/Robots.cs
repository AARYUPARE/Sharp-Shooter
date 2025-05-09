using UnityEngine;
using UnityEngine.AI;

public class Robots : MonoBehaviour
{
    [SerializeField] Transform target;

    const string PLAYER_STRING = "Player";

    NavMeshAgent agent;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if(!target) { return; }
        agent.SetDestination(target.position);
    }

    public void SetTarget(Transform target)
    {
        this.target = target;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(PLAYER_STRING))
        {
            EnemyHealth enemyHealth = GetComponent<EnemyHealth>();

            enemyHealth.SelfDestruct();
        }
    }
}
