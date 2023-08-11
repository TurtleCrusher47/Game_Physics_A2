using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] private GameObject ball;

    private bool isTriggered = false;

    void OnTriggerEnter(Collider col)
    {
        if (!isTriggered)
        {
            isTriggered = true;
        }
    }
}
