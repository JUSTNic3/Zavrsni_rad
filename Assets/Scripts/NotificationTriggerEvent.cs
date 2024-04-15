using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotificationTriggerEvent : MonoBehaviour
{
    [Header("UI Content")]
    public Text notificationText;

    [Header("Message Customization")]
    [TextArea] public string notificationMessage;

    [Header("Notification Remowal")]
    public bool removeAfterExit = false;
    public bool disableAfterTimer = false;
    public float disableTimer =  1.0f;

    [Header("Notification Animation")]
    public Animator notificationAnim;
    public BoxCollider objectCollider;
    

    public void Awake() 
    {   
        objectCollider = gameObject.GetComponent<BoxCollider>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            StartCoroutine(EnableNotification());

        }
    }

       public void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player") && removeAfterExit)
        {
            RemoveNotification();
        }
    }

    public IEnumerator EnableNotification()
    {
        objectCollider.enabled = false;
        notificationAnim.Play("NotificationFadeIn");
        notificationText.text = notificationMessage;

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