using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandTeaseAnimation : MonoBehaviour
{
    [SerializeField] Animator handAnimation;
    [SerializeField] BoxCollider handCollider;

    public void Awake()
    {
        handCollider = gameObject.GetComponent<BoxCollider>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            handAnimation.Play("hand_teaser");
            gameObject.SetActive(false);
        }
    }
}
