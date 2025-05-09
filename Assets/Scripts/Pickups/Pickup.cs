using UnityEngine;
using UnityEngine.EventSystems;

abstract public class Pickup : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 100f;

    const string playerTag = "Player";

    void Update()
    {
        transform.Rotate(0, rotationSpeed, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            OnPickup(other.gameObject);
            Destroy(this.gameObject);
        }
    }

    abstract protected void OnPickup(GameObject player);
}
