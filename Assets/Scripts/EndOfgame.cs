using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndOfgame : MonoBehaviour
{
    [SerializeField] BoxCollider end_collider;
    // Start is called before the first frame update
    public void Awake()
    {
        end_collider = gameObject.GetComponent<BoxCollider>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SlimeMonster"))
        {
            SceneManager.LoadScene(0);
        }
    }
}
