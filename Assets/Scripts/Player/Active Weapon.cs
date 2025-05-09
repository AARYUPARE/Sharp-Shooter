using Cinemachine;
using StarterAssets;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ActiveWeapon : MonoBehaviour
{
    [SerializeField] WeaponSO startingWeaponSO;
    [SerializeField] CinemachineVirtualCamera cinemachineVirtualCamera;
    [SerializeField] WeaponInventory weaponInventory;
    [SerializeField] Camera weaponCamera;
    [SerializeField] GameObject zoomVignetteImage;
    [SerializeField] TMP_Text ammoText;

    WeaponSO currentWeaponSO;
    Animator animator;
    StarterAssetsInputs starterAssetsInputs;
    FirstPersonController firstPersonController;
    Weapon currentWeapon;
    const string shootString = "Shoot";

    float elapsedTime = 1f;
    float defaultRotationSpeed;
    float defaultFOV;

    int currentAmmo;

    void Awake()
    {
        starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();
        animator = GetComponent<Animator>();
        firstPersonController = GetComponentInParent<FirstPersonController>();
        defaultRotationSpeed = firstPersonController.RotationSpeed;
    }

    void Start()
    {
        SwitchWeapon(startingWeaponSO);
        weaponInventory.GetWeapon(startingWeaponSO);
        defaultFOV = currentWeaponSO.defaultFOV;
        AdjustAmmo(currentWeaponSO.MagazineSize);
    }

    void Update()
    {
        HandleShoot();
        HandleZoom();
    }

    public void AdjustAmmo(int amount)
    {
        currentWeaponSO.CurrentAmmo += amount;
        currentWeaponSO.CurrentAmmo = Mathf.Clamp(currentWeaponSO.CurrentAmmo, 0, currentWeaponSO.MagazineSize);

        ammoText.text = currentWeaponSO.CurrentAmmo.ToString("D2");
    }

    private void HandleShoot()
    {
        elapsedTime += Time.deltaTime;

        if (!starterAssetsInputs.shoot) { return; }

        if(elapsedTime >= currentWeaponSO.FireRate && currentWeaponSO.CurrentAmmo > 0)
        {
            currentWeapon.Shoot(currentWeaponSO);
            animator.Play(shootString, 0, 0f);
            elapsedTime = 0;
            AdjustAmmo(-1);
        }

        if(!currentWeaponSO.IsAutomatic)
        {
            starterAssetsInputs.ShootInput(false);
        }


    }

    void HandleZoom()
    {
        if (!currentWeaponSO.CanZoom) { return; }

        if(starterAssetsInputs.zoom)
        {
            cinemachineVirtualCamera.m_Lens.FieldOfView = currentWeaponSO.ZoomAmount;
            weaponCamera.fieldOfView = currentWeaponSO.ZoomAmount;
            zoomVignetteImage.SetActive(true);
            firstPersonController.ChangeRotationSpeed(currentWeaponSO.RotationSpeed);
        }
        else
        {
            cinemachineVirtualCamera.m_Lens.FieldOfView = currentWeaponSO.defaultFOV;
            weaponCamera.fieldOfView = defaultFOV;
            zoomVignetteImage.SetActive(false);
            firstPersonController.ChangeRotationSpeed(defaultRotationSpeed);
        }
    }

    public void SwitchWeapon(WeaponSO weaponSO)
    {
        if(currentWeapon)
        {
            Destroy(currentWeapon.gameObject);
        }

        Weapon newWeapon = Instantiate(weaponSO.WeaponPrefab, transform).GetComponent<Weapon>();
        currentWeapon = newWeapon;
        this.currentWeaponSO = weaponSO;
        AdjustAmmo(0);
    }
}
