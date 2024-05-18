using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class Finalna_scena : MonoBehaviour
{
    [SerializeField] GameObject little_shits;
    [SerializeField] GameObject fakeDoor;
    [SerializeField] GameObject realDoor;
    //[SerializeField] BoxCollider scena_collider;
    [SerializeField] GameObject kamera;
    [SerializeField] GameObject ScreechCamera;
    [SerializeField] GameObject error;
    [SerializeField] GameObject Greenlight;
    [SerializeField] GameObject RedLight;
    [SerializeField] GameObject FinalLightsOff;
    [SerializeField] AudioSource Eerie;
    [SerializeField] AudioSource Screech;
    [SerializeField] AudioSource CameraBreak;
    [SerializeField] AudioSource Static;
    public bool IsMad = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pocetak_scene()
    {
        fakeDoor.SetActive(false);
        realDoor.SetActive(true);
        little_shits.SetActive(true);
        Eerie.Play();
        Invoke("Screech_scene", 4);
    }
    public void Screech_scene()
    {
        kamera.SetActive(false);
        ScreechCamera.SetActive(true);
        Screech.Play();
        Invoke("Cutscene", 1);
    }
    public void Cutscene()
    {
        CameraBreak.Play();
        FinalLightsOff.SetActive(false);
        ScreechCamera.SetActive(false);
        error.SetActive(true);
        Greenlight.SetActive(false);
        RedLight.SetActive(true);
        Static.Play();
        IsMad = true;
    }
}
