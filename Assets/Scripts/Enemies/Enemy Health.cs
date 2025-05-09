using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] GameObject robotDestroyVFX;
    [SerializeField] int health = 3;

    int currentHealth;

    GameManager gameManager;

    void Start()
    {
        currentHealth = health;
        gameManager = FindAnyObjectByType<GameManager>();
        gameManager.AdjustEnemiesLeft(1);
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if(currentHealth <= 0)
        {
            SelfDestruct();
            gameManager.AdjustEnemiesLeft(-1);
        }
    }

    public void SelfDestruct()
    {
        Instantiate(robotDestroyVFX, transform.position, Quaternion.identity);
        
        Destroy(this.gameObject);
    }
}
