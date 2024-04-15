using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControl : MonoBehaviour
{
    [SerializeField] public Animator myDoor = null;
    [SerializeField] public Animator SecurityDoor = null;

    public bool DoorOpen = false;
    public bool SecurityDoorOpen = false;
}
