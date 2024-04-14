using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Raycast : MonoBehaviour
{
    //[SerializeField] public LayerMask layermask;
    [SerializeField] public float maxDistance;
    public PhoneController voicebox;
    public DoorControl door;
    public LightSwitch lampa;
    Mouse mouse = Mouse.current;
    int PhoneFlag = 0;
    [SerializeField] GameObject fake;
    [SerializeField] GameObject real;
    void Awake()
    {
        voicebox = GameObject.Find("MainCamera").GetComponent<PhoneController>();
    }
    void Update()
    {
        RaycastHit hit;
        Vector3 direction = Vector3.forward;
        Ray play = new Ray(transform.position, transform.TransformDirection(direction * maxDistance));
        Debug.DrawRay(transform.position, transform.TransformDirection(direction * maxDistance), Color.red);

        if (mouse.leftButton.wasPressedThisFrame)
        {
            if (Physics.Raycast(play, out hit, maxDistance) && hit.transform.CompareTag("Phone"))
            {
                if(PhoneFlag == 0)
                {
                    voicebox.ringing.Stop();
                    voicebox.recording.Play();
                    PhoneFlag = 1;
                }
                else
                {
                    voicebox.recording.Stop();
                    PhoneFlag = 0;
                }
                
            }
            if (Physics.Raycast(play, out hit, maxDistance) && hit.transform.CompareTag("Untagged"))
            {
                fake.SetActive(false);
                real.SetActive(true);
            }
            if (Physics.Raycast(play, out hit, maxDistance) && hit.transform.CompareTag("Door"))
            {
                if(door.DoorOpen)
                {
                    door.myDoor.Play("door_close", 0, 0.0f);
                    door.DoorOpen = false;
                }
                else
                {
                    door.myDoor.Play("door_open", 0, 0.0f);
                    door.DoorOpen = true;
                }
            }
            if (Physics.Raycast(play, out hit, maxDistance) && hit.transform.CompareTag("Box"))
            {
                if(lampa.BoxDoorOpen)
                {
                    lampa.BoxDoor.Play("box_close", 0, 0.0f);
                    lampa.BoxDoorOpen = false;
                }
                else
                {
                    lampa.BoxDoor.Play("box_open", 0, 0.0f);
                    lampa.BoxDoorOpen = true;
                }
            }
            if (Physics.Raycast(play, out hit, maxDistance) && lampa.BoxDoorOpen && hit.transform.CompareTag("Lever"))
            {
                lampa.LeverUp.Play("lever_up", 0, 0.0f);
                lampa.LeverDown = false;
                lampa.lamp.SetActive(true);
            }
        }
        
    }
}
