using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public PlatformMove Mover;
 
    private void OnTriggerStay(Collider other)
    {
        Mover.HandinBox = true;
    }

    private void OnTriggerExit(Collider other)
    {
        Mover.HandinBox = false;
    }
}
