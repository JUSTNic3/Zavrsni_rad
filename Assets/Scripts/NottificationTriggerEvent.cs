using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NottificationTriggerEvent : MonoBehaviour
{
    [Header("UI Content")]
    [SerializeField] private Text notificationText;
    //[SerializeField] private Image

    [Header("Message Customization")]
    [SerializeField] [TextArea] private string notifiactionMessage;

    [Header("Notification Remowal")]
    [SerializeField] private bool removeAfterExit = false;
    [SerializeField] private bool disableAfterTimer = false;
    [SerializeField] private float disableTimer =  1.0f;

    [Header("Notification Animation")]
    [SerializeField] private Animator notificationAnim;
    private BoxCollider objectCollider; 

    private void Awake() 
    {   
        objectCollider = gameObject.GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            StartCoroutine(EnableNotification());

        }
    }

       private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player") && removeAfterExit)
        {
            RemoveNotification();
        }
    }

    IEnumerator EnableNotification()
    {
        objectCollider.enabled = false;
        notificationAnim.Play("NotificationFadeIn");
        notificationText.text = notifiactionMessage;

        if(disableAfterTimer)
        {
            yield return new WaitForSeconds(disableTimer);
            RemoveNotification();
        }
    }

    void RemoveNotification()
    {
        notificationAnim.Play("NotificationFadeOut");
        gameObject.SetActive(false);
    }
}