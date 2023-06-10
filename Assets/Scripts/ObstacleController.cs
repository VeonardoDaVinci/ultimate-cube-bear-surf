using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public int obstacleHeight = 1;
    private BoxCollider boxCollider;
    private ObstacleWrapperController parent;
    private bool isUsed = false;
    private void Start()
    {
        parent = transform.parent.GetComponent<ObstacleWrapperController>();
        boxCollider= GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (obstacleHeight > parent.CurrentHighestHitByPlayer)
            {
                parent.CurrentHighestHitByPlayer = obstacleHeight;

            }
        }
    }

}
