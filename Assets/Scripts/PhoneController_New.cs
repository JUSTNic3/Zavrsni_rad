using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneController_New : MonoBehaviour
{
    public AudioSource ringing;
    public AudioSource recording;
    // Start is called before the first frame update
    void Start()
    {
        ringing.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
