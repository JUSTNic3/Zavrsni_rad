using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Threading;

public class Raycast : MonoBehaviour
{
    //[SerializeField] public LayerMask layermask;
    [SerializeField] public float maxDistance;
    public PhoneController voicebox;
    public GameObject light_notif;
    public GameObject noise_notif;
    [SerializeField] private GameObject lightsOff;
    [SerializeField] AudioSource powerOut;
    public DoorControl door;
    public LightSwitch lampa;
    Mouse mouse = Mouse.current;
    [SerializeField] AudioSource bangingOnDoorAndBoom;
    [SerializeField] bool HasDestroyed = false;
    int PhoneFlag = 0;
    [SerializeField] GameObject fake;
    [SerializeField] GameObject real;
    [SerializeField] GameObject fakeDoor;
    [SerializeField] GameObject brokenDoor;
    private bool KeyCollected = false;
    [SerializeField] GameObject key;
    public Finalna_scena jumpscare;
    [SerializeField] Animator breakDoorAnim;
    [SerializeField] bool DoorBrokenDown = false;
    [SerializeField] bool FinaleTrigger = false;
    [SerializeField] GameObject replacement;
    [SerializeField] GameObject old_camera;
    [SerializeField] GameObject final_banging;
    [SerializeField] GameObject final_monster;
    void Awake()
    {
        voicebox = GameObject.Find("MainCamera").GetComponent<PhoneController>();
        final_monster.SetActive(false);
    }
    void Update()
    {
        RaycastHit hit;
        Vector3 direction = Vector3.forward;
        Ray play = new Ray(transform.position, transform.TransformDirection(direction * maxDistance));
        //Debug.DrawRay(transform.position, transform.TransformDirection(direction * maxDistance), Color.red);

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
                light_notif.SetActive(true);
                lightsOff.SetActive(false);
                powerOut.Play();
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
                if(lampa.LeverDown)
                {
                    if (HasDestroyed)
                    {
                        lampa.LeverUp.Play("lever_up", 0, 0.0f);
                        lampa.LeverDown = false;
                        lightsOff.SetActive(true);
                    }
                    else
                    {
                        lampa.LeverUp.Play("lever_up", 0, 0.0f);
                        lampa.LeverDown = false;
                        lightsOff.SetActive(true);
                        bangingOnDoorAndBoom.Play();
                        noise_notif.SetActive(true);
                        fakeDoor.SetActive(false);
                        brokenDoor.SetActive(true);
                        HasDestroyed = true;
                    }
                }
                else
                {
                    lampa.LeverUp.Play("lever_down", 0, 0.0f);
                    lampa.LeverDown = true;
                    lightsOff.SetActive(false);
                    powerOut.Play();
                }
                
            }
            if (Physics.Raycast(play, out hit, maxDistance) && hit.transform.CompareTag("Key"))
            {
                key.SetActive(false);
                KeyCollected = true;
            }
            if (Physics.Raycast(play, out hit, maxDistance) && hit.transform.CompareTag("SecurityDoor") && KeyCollected)
            {
                if (door.SecurityDoorOpen)
                {
                    door.SecurityDoor.Play("security_door_close", 0, 0.0f);
                    door.SecurityDoorOpen = false;
                }
                else
                {
                    door.SecurityDoor.Play("security_door_open", 0, 0.0f);
                    door.SecurityDoorOpen = true;
                }
            }
        }
        if (Physics.Raycast(play, out hit, 2) && hit.transform.CompareTag("Camera"))
        {
            if (!FinaleTrigger)
            {
                jumpscare.Pocetak_scene();
                final_monster.SetActive(true);
                FinaleTrigger = true;
            }
        }
        if (jumpscare.IsMad)
        {
            Invoke("sound_breaking", 4);
        }
    }
    void sound_breaking()
    {
        final_banging.SetActive(true);
        Invoke("door_breaking", 4);
    }
    void door_breaking()
    {
        if (!DoorBrokenDown)
        {
            breakDoorAnim.Play("door_breakdown", 0, 0.0f);
            replacement.SetActive(true);
            old_camera.SetActive(false);
            DoorBrokenDown = true;
        }
    }
}
