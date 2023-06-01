using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{
    public GameObject torchFlame;
    public void Interact()
    {
        torchFlame.SetActive(!torchFlame.activeSelf);
    }
}
