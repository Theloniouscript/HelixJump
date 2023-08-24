using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Ping");
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Pong");
    }
}
