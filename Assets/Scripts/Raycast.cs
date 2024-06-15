using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Threading;
using UnityEngine.SceneManagement;

public class Raycast : MonoBehaviour
{
    //[SerializeField] public LayerMask layermask;
    [SerializeField] public float maxDistance;
    [SerializeField] Animator Entrace_door;
    [SerializeField] GameObject Entrance_Door;
    [SerializeField] GameObject Entrance_Door_Locked;
    private bool EntranceClosed = true;
    public PhoneController voicebox;
    public GameObject light_notif;
    public GameObject key_notif;
    private bool key_notification = false;
    public GameObject noise_notif;
    [SerializeField] private GameObject lightsOff;
    [SerializeField] AudioSource powerOut;
    [SerializeField] bool RiggedPowerOut = false;
    public DoorControl door;
    public LightSwitch lampa;
    [SerializeField] bool FirstPull = false;
    Mouse mouse = Mouse.current;
    [SerializeField] AudioSource bangingOnDoorAndBoom;
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
    [SerializeField] Animator final_intro;
    [SerializeField] AudioSource monster_screech;
    [SerializeField] AudioSource monster_dying;
    [SerializeField] GameObject monster_eating_monster;
    [SerializeField] AudioSource monster_showing_eating;
    [SerializeField] Animator monster_showing;
    [SerializeField] GameObject little_shit;
    [SerializeField] GameObject LittleShitsBroken;
    [SerializeField] GameObject last_hope_object;
    [SerializeField] GameObject FinalTrigger;
    [SerializeField] Animator SlimeMonster;
    [SerializeField] GameObject FinalCamera;
    [SerializeField] Animator CameraAnimation;
    [SerializeField] GameObject Player_capsule;
    [SerializeField] AudioSource MonsterNoises;
    [SerializeField] AudioSource monster_jumpscare;

    void Awake()
    {
        voicebox = GameObject.Find("MainCamera").GetComponent<PhoneController>();
        final_monster.SetActive(false);
        monster_eating_monster.SetActive(false);
        last_hope_object.SetActive(false);
        FinalTrigger.SetActive(false);
    }
    void Update()
    {
        Cursor.visible = false;
        RaycastHit hit;
        Vector3 direction = Vector3.forward;
        Ray play = new Ray(transform.position, transform.TransformDirection(direction * maxDistance));

        if (mouse.leftButton.wasPressedThisFrame)
        {
            if (Physics.Raycast(play, out hit, maxDistance) && hit.transform.CompareTag("Entrance_door"))
            {
                if (EntranceClosed)
                {
                    Entrace_door.Play("entrance_door_open", 0, 0.0f);
                    EntranceClosed = false;
                }
                else
                {
                    Entrace_door.Play("entrance_door_close", 0, 0.0f);
                    EntranceClosed = true;
                }
            }
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
            if (Physics.Raycast(play, out hit, maxDistance) && hit.transform.CompareTag("Flash"))
            {
                fake.SetActive(false);
                real.SetActive(true);
                light_notif.SetActive(true);
                lightsOff.SetActive(false);
                powerOut.Play();
                RiggedPowerOut = true;
                Entrance_Door.SetActive(false);
                Entrance_Door_Locked.SetActive(true);
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
                     lampa.LeverUp.Play("lever_up", 0, 0.0f);
                     lampa.LeverDown = false;
                     lightsOff.SetActive(true);
                     FirstPull = true;
                    if (FirstPull)
                    {
                        key_notif.SetActive(true);
                        key_notification = true;
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
            if (Physics.Raycast(play, out hit, maxDistance) && hit.transform.CompareTag("Key") && RiggedPowerOut && key_notification)
            {
                key.SetActive(false);
                KeyCollected = true;
                bangingOnDoorAndBoom.Play();
                fakeDoor.SetActive(false);
                brokenDoor.SetActive(true);
                noise_notif.SetActive(true);
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
        if (Physics.Raycast(play, out hit, 20) && hit.transform.CompareTag("SlimeMonster"))
            {
                Player_capsule.SetActive(false);
                SlimeMonster.Play("turning_around", 0, 0.0f);
                old_camera.SetActive(false);
                FinalCamera.SetActive(true);
                Invoke("final_jumpscare", 6);
            }
        if (Physics.Raycast(play, out hit, 3) && hit.transform.CompareTag("PartOfMonster"))
            {
                FinalTrigger.SetActive(true);
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
            Invoke("finale_introduction",2);
        }
    }
    void finale_introduction(){
        final_intro.Play("finale", 0, 0.0f);
        monster_screech.Play();
        Invoke("monster_eating_monster_animation", 2);
    }
    void monster_eating_monster_animation(){
        monster_eating_monster.SetActive(true);
        final_monster.SetActive(false);
        monster_dying.Play();
        monster_showing_eating.Play();
        monster_showing.Play("monster_showing", 0, 0.0f);
        Invoke("monster_leaving", 6);
    }
    void monster_leaving(){
        monster_showing.Play("Leaving", 0, 0.0f);
        last_hope_object.SetActive(true);
        Invoke("last_hope", 5);
    }
    void last_hope(){
        replacement.SetActive(false);
        old_camera.SetActive(true);
        little_shit.SetActive(false);
        jumpscare.little_shits.SetActive(false);
        LittleShitsBroken.SetActive(true);
    }
    void final_jumpscare(){
        SlimeMonster.Play("final_jumpscare", 0, 0.0f);
        MonsterNoises.Stop();
        monster_jumpscare.Play();
        CameraAnimation.Play("camera_moving_away", 0, 0.0f);
        Invoke("theEnd", 12);
    }
    void theEnd(){
        SceneManager.LoadScene(2);
        Cursor.visible = true;
    }
}
