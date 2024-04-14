using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorExplosion : MonoBehaviour
{
    [SerializeField] AudioSource damage;

    void OnTriggerEnter(Collider other)
    {
        damage.Play();
    }

}
