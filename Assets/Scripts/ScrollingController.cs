using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class ScrollingController : MonoBehaviour
{
    private void FixedUpdate()
    {
        transform.position -= new Vector3(0.1f,0f,0f);
    }

}
