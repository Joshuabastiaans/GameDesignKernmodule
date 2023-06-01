using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Inventory : MonoBehaviour
{
    private bool hasTorch;

    public void AddTorch()
    {
        hasTorch = true;
    }

    public bool HasTorch()
    {
        return hasTorch;
    }
}

