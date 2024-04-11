using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [SerializeField] GameObject lightSource;
    // Start is called before the first frame update
    void Start()
    {
        lightSource.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("Pressed");
            lightSource.SetActive(true);
        }
    }
}
