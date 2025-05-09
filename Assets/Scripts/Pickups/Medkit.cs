using UnityEngine;

public class Medkit : Pickup
{
    [SerializeField] int point = 2;
    
    PickupSpawner pickupSpawner;

    void Start()
    {
        pickupSpawner = GetComponentInParent<PickupSpawner>();
    }

    protected override void OnPickup(GameObject player)
    {
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
        playerHealth.GainHealth(point);
        pickupSpawner.InitRoutine();
    }
}
