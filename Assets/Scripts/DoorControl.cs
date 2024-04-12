using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControl : MonoBehaviour
{
    [SerializeField] private Animator myDoor = null;

    [SerializeField] private bool openTrigger = false;
    [SerializeField] private bool closeTrigger = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(openTrigger)
            {
                myDoor.Play("door_open", 0, 0.0f);
                gameObject.SetActive(false);
            }
            if(closeTrigger)
            {
                myDoor.Play("door_close", 0, 0.0f);
                gameObject.SetActive(false);
            }
        }
    }
}
