using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandDelete : MonoBehaviour
{
    [SerializeField] GameObject monster;
    [SerializeField] BoxCollider deleteCollider;

    public void Awake()
    {
        deleteCollider = gameObject.GetComponent<BoxCollider>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            monster.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
