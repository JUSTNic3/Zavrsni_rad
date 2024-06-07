using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Threading;

public class finalCutscene : MonoBehaviour
{
    [SerializeField] BoxCollider playerCollide;
    [SerializeField] GameObject SlimeMonster;
    [SerializeField] AudioSource monsterNoises;
    [SerializeField] GameObject Wall;

    public void Awake()
    {
        playerCollide = gameObject.GetComponent<BoxCollider>();
        SlimeMonster.SetActive(false);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {  
            Wall.SetActive(false);
            SlimeMonster.SetActive(true);
            monsterNoises.Play();
            gameObject.SetActive(false);
        }
    }
}
