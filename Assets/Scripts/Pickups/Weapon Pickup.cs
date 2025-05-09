using UnityEngine;

public class WeaponPickup : Pickup
{
    [SerializeField] WeaponSO weaponSO;

    protected override void OnPickup(GameObject player)
    {
        ActiveWeapon activeWeapon = player.GetComponentInChildren<ActiveWeapon>();
        activeWeapon.SwitchWeapon(weaponSO);
        activeWeapon.AdjustAmmo(weaponSO.MagazineSize);
        WeaponInventory weaponInventory = player.GetComponentInChildren<WeaponInventory>();
        weaponInventory.GetWeapon(weaponSO);
    }
}
