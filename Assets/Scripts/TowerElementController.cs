using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerElementController : MonoBehaviour
{
    public event Action<int> TowerCollideEvent;
    public bool isUsed = false;
    public void InvokeCollideEvent(int height)
    {
        TowerCollideEvent?.Invoke(height);
    }
}
