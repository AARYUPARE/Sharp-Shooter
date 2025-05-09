using System.Collections;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] Transform turretHead;
    [SerializeField] Transform playerTargetPoint;
    [SerializeField] Transform projectileSpawnPoint;
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpawnInterval = 2f;

    void Start()
    {
        StartCoroutine(FireRoutine());
    }

    void Update()
    {
        turretHead.LookAt(playerTargetPoint);
    }

    IEnumerator FireRoutine()
    {
        while(playerTargetPoint)
        {
            GameObject projectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, turretHead.rotation);
            projectile.transform.LookAt(playerTargetPoint);
            yield return new WaitForSeconds(projectileSpawnInterval);
        }
    }
}
