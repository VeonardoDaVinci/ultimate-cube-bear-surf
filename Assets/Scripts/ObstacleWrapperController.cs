using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ObstacleWrapperController : MonoBehaviour
{
    public int CurrentHighestHitByPlayer = 0;
    public event Action<int> CollisionEvent;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CollisionEvent?.Invoke(CurrentHighestHitByPlayer);
        }   
    }
}
