using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Raycast_New : MonoBehaviour
{
    //[SerializeField] public LayerMask layermask;
    [SerializeField] public float maxDistance;
    [SerializeField] private string ObjectTag;
    Mouse mouse = Mouse.current;
    void Update()
    {
        RaycastHit hit;
        Vector3 direction = Vector3.forward;
        Ray play = new Ray(transform.position, transform.TransformDirection(direction * maxDistance));
        Debug.DrawRay(transform.position, transform.TransformDirection(direction * maxDistance), Color.red);

        if (mouse.leftButton.wasPressedThisFrame)
        {
            if (Physics.Raycast(play, out hit, maxDistance) && hit.transform.CompareTag(ObjectTag))
            {
                print("We have ingnition");
            }
        }
        
    }
}
