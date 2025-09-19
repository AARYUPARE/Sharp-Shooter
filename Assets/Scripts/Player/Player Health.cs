using Cinemachine;
using StarterAssets;
using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [Range(1, 10)]
    [SerializeField] int health = 5;
    [SerializeField] CinemachineVirtualCamera deathVirtualCamera;
    [SerializeField] Transform weaponCamera;
    [SerializeField] Image[] shieldBar;
    [SerializeField] GameObject gameOverContainer;

    float currentHealth;
    int gameOverVirtualCameraPriority = 20;

    void Awake()
    {
        currentHealth = health;
        AdjustShieldUI();
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        AdjustShieldUI();

        if (currentHealth <= 0)
        {
            PlayerGameOver();
        }
    }
    
    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        AdjustShieldUI();

        if (currentHealth <= 0)
        {
            PlayerGameOver();
        }
    }

    public void GainHealth(int amount)
    {
        currentHealth += amount;
        AdjustShieldUI();

        if(currentHealth > health)
        {
            currentHealth = health;
        }
    }
    
    public void GainHealth(float amount)
    {
        currentHealth += amount;
        AdjustShieldUI();

        if(currentHealth > health)
        {
            currentHealth = health;
        }
    }

    void PlayerGameOver()
    {
        weaponCamera.parent = null;
        deathVirtualCamera.Priority = gameOverVirtualCameraPriority;
        gameOverContainer.SetActive(true);
        StarterAssetsInputs starterAssetsInputs = GetComponent<StarterAssetsInputs>();
        starterAssetsInputs.SetCursorState(false);
        Destroy(this.gameObject);
    }

    private void AdjustShieldUI()
    {
        for(int i = 0; i < shieldBar.Length; i++)
        {
            if(i < currentHealth)
            {
                shieldBar[i].gameObject.SetActive(true);
            }
            else
            {
                shieldBar[i].gameObject.SetActive(false);
            }
        }
    }
}
