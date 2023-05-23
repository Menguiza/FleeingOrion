using UnityEngine;
using UnityEngine.Events;

public class PlayerHallDetected : MonoBehaviour
{
    public UnityEvent PlayerEntered;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")) PlayerEntered.Invoke();
    }
}
