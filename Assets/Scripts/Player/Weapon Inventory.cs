using StarterAssets;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponInventory : MonoBehaviour
{
    [SerializeField] ActiveWeapon activeWeapon;

    WeaponSO[] weaponSOS = new WeaponSO[3];

    StarterAssetsInputs starterAssetsInputs;

    int activeWeaponIndex = 1;
    int addIndex = 0;

    void Awake()
    {
        starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();
    }

    private void Update()
    {
        SwitchWeapon();
    }

    public void GetWeapon(WeaponSO weaponSO)
    {
        weaponSOS[addIndex] = weaponSO;
        Debug.Log(weaponSOS[addIndex].name);
        addIndex++;
    }

    void SwitchWeapon()
    {
        if(!starterAssetsInputs.switchWeapon) { return; }

        if(activeWeaponIndex >= addIndex)
        {
            activeWeaponIndex = 0;
        }

        activeWeapon.SwitchWeapon(weaponSOS[activeWeaponIndex]);
        activeWeaponIndex++;

        starterAssetsInputs.SwitchWeaponInput(false);
    }

}
