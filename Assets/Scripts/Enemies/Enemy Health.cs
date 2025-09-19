using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    static float mul = 1.0f;
    static List<EnemyHealth> allEnemies = new List<EnemyHealth>();

    [SerializeField] GameObject robotDestroyVFX;
    [SerializeField] int health = 3;

    float currentHealth;

    GameManager gameManager;

    void Start()
    {
        currentHealth = health * mul;
        gameManager = FindAnyObjectByType<GameManager>();
        gameManager.AdjustEnemiesLeft(1);

        allEnemies.Add(this);
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

    public static void AdjustMultiplier(float mul)
    {
        EnemyHealth.mul = mul;

        foreach(var enemy in allEnemies)
        {
            float ratio = enemy.currentHealth / enemy.health;  
            enemy.health = Mathf.RoundToInt(enemy.health * mul); 
            enemy.currentHealth = enemy.health * ratio;
        }
    }
    
    public void TakeDamage(float amount)
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

    private void OnDestroy()
    {
        allEnemies.Remove(this);
    }
}
