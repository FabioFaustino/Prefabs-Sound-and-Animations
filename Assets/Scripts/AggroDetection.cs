using System;
using UnityEngine;


public class AggroDetection : MonoBehaviour
{
    public event Action<Transform> OnAggro = delegate { };

    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<PlayerController>();
        if (player != null)
        {
            OnAggro(player.transform);         
            // Chase after player
            //GetComponent<NavMeshAgent>().SetDestination(player.transform.position);
        }
    }
}
    
