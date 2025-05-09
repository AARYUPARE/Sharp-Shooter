using System.Collections;
using UnityEngine;

public class SpawnGate : MonoBehaviour
{
    [SerializeField] GameObject robotPrefab;
    [SerializeField] Transform spawnPosition;
    [SerializeField] float robotSpawnInterval = 5f;
    [SerializeField] Transform target;

    void Start()
    {
        StartCoroutine(SpawnRobotRoutine());
    }

    IEnumerator SpawnRobotRoutine()
    {
        while(target)
        {
            Robots robot = Instantiate(robotPrefab, spawnPosition.position, transform.rotation).GetComponent<Robots>();
            robot.SetTarget(target);
            yield return new WaitForSeconds(robotSpawnInterval);
        }
    }
}
