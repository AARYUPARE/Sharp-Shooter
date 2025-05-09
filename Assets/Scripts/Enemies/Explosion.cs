using System.Runtime.CompilerServices;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    
    [SerializeField] int explosionDamage = 1;
    [SerializeField] float radius = 1.5f;

    const string PLAYER_STRING = "Player";

    void Start()
    {
        Explode();
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
    
    public void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider collider in colliders)
        {
            PlayerHealth playerHealth = collider.GetComponent<PlayerHealth>();

            if(playerHealth)
            {
                playerHealth.TakeDamage(explosionDamage);
            }
        }
    }
}
