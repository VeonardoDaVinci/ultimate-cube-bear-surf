using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationController : MonoBehaviour
{
    [SerializeField] private GameObject level;
    [SerializeField] private GameObject player;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            level.transform.DORotate(new Vector3(0, level.transform.eulerAngles.y + 90f, 0), 1f);
        }
    }
}
