using UnityEngine;

public class AmmoPickup : Pickup
{
    [SerializeField] int ammoAmount = 100;
    
    PickupSpawner pickupSpawner;

    void Start()
    {
        pickupSpawner = GetComponentInParent<PickupSpawner>();
    }

    protected override void OnPickup(GameObject player)
    {
        ActiveWeapon activeWeapon = player.GetComponentInChildren<ActiveWeapon>();
        activeWeapon.AdjustAmmo(ammoAmount);
        pickupSpawner.InitRoutine();
    }
}
