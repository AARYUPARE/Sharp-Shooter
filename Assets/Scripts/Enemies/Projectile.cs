using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float forwardVelocity = 2f;
    [SerializeField] int damage = 2;
    [SerializeField] GameObject hitVFX;

    Rigidbody rb;

    const string PLAYER_STRING = "Player";

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        rb.linearVelocity = transform.forward * Time.deltaTime * forwardVelocity;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(PLAYER_STRING))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(damage);
        }

        Instantiate(hitVFX, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
