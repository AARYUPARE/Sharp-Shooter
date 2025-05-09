using System.Collections;
using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    [SerializeField] GameObject pickup;
    [SerializeField] Transform spawnPoint;
    [SerializeField] float SpawnInterval = 10f;

    public bool picked;

    void Start()
    {
        Instantiate(pickup, spawnPoint.position, Quaternion.identity, spawnPoint);
    }

    //void Update()
    //{
    //    if(!picked) { return; }

    //    StartCoroutine(SpawnRoutine());
    //}

    public void InitRoutine()
    {
        StartCoroutine(SpawnRoutine());
        //this.picked = picked;
    }

    IEnumerator SpawnRoutine()
    {
        //picked = false;
        yield return new WaitForSeconds(SpawnInterval);
        Instantiate(pickup, spawnPoint.position, Quaternion.identity, spawnPoint);
    }
}
